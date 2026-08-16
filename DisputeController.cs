using Microsoft.AspNetCore.Mvc;
using SIH_2026.Models;
using SIH_2026.Data;
namespace SIH_2026.Controllers;

[ApiController]
[Route("api/[controller]")]

public class DisputeController : ControllerBase
{
    private readonly AppDbContext _db;
    public DisputeController(AppDbContext db)
    {
        _db = db;
    }
    [HttpPost]
    public IActionResult Create(Dispute dispute)
    {
        var trip = _db.Trips.Find(dispute.TripId);
        if (trip == null) return NotFound("Trip not find");
        dispute.Status = "submitted";
        _db.Dispute.Add(dispute);
        _db.SaveChanges();
        return Ok(dispute);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return  Ok(_db.Dispute.ToList());
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var dispute = _db.Dispute.Find(id);
        if (dispute == null) return NotFound();
        return Ok(dispute);
    }
}

