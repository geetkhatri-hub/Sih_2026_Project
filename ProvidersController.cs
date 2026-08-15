using Microsoft.AspNetCore.Mvc;
using SIH_2026.Data;
using SIH_2026.Models;
using SIH_2026.Services;
namespace SIH_2026.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProvidersController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IQrService _qrservice;
    public ProvidersController(AppDbContext db, IQrService qrservice)
    {
        _db = db;
        _qrservice = qrservice;
    }
    [HttpPost("register")]
    public IActionResult Register(Provider provider)
    {
        provider.VerificationStatus = "pending";
        _db.Providers.Add(provider);
        _db.SaveChanges();
        return Ok(new { provider.ID, provider.VerificationStatus });
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Providers.ToList());
    }

    [HttpPost("{id}/approve")]
    public IActionResult Approve(int id)
    {
        var provider = _db.Providers.Find(id);
        if (provider == null) return NotFound();

        provider.VerificationStatus = "verified";
        provider.QrPayload = $"YT-PRV-{provider.ID}";
        _db.SaveChanges();

        return Ok(new { provider.ID, provider.VerificationStatus,provider.QrPayload });

   }

    [HttpGet("{id}/qrcode")]
    public IActionResult GetQrCOde(int id)
    {
        var provider = _db.Providers.Find(id);
        if (provider == null || provider.QrPayload==null)
          return NotFound("Provider is not verified");
        var qrBytes = _qrservice.GenerateQrCode(provider.QrPayload);
        return File(qrBytes, "image/png");
    }
    [HttpGet("by-qr/{payload}")]
    public IActionResult GetByQr(string payload)
    {
        var provider = _db.Providers.FirstOrDefault(p => p.QrPayload == payload);
        if (provider == null)
            return NotFound();
        return Ok(provider);
    }
}