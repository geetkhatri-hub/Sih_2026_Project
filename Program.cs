using Microsoft.EntityFrameworkCore;

using SIH_2026.Data;
using SIH_2026.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IQrService, QrService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!db.Providers.Any())
    {
        var demoProvider = new SIH_2026.Models.Provider
        {
            Name = "Rakesh Verma",
            Phone = "9999999999",
            Address = "Agra",
            VehicalType = "Auto-rickshaw",
            VehicalNumber = "UP80-AB-1234",
            VerificationStatus = "verified",
            QrPayload = "YT-PRV-1"
        };
        db.Providers.Add(demoProvider);
        db.SaveChanges();
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 👇 Add these for frontend
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();
