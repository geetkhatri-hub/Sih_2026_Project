using Microsoft.EntityFrameworkCore;
using SIH_2026.Models;
namespace SIH_2026.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Dispute> Dispute { get; set; }
    }
}
