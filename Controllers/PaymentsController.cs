using Microsoft.AspNetCore.Mvc;
using SIH_2026.Data;
using SIH_2026.Models;
using System.Runtime.CompilerServices;
namespace SIH_2026.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PaymentsController:ControllerBase
{
    private readonly AppDbContext _db;
    public PaymentsController(AppDbContext db)
    {
        _db = db;
    }
    [HttpPost]
    public IActionResult Create(Payment payment) {
        if (payment.Method != "Cash" && payment.Method != "Online")
            return BadRequest("Method must be in 'Cash' or 'Online' ");
        var trip = _db.Trips.Find(payment.TripID);
        if (trip == null) return NotFound("Trip not found");

        _db.Payments.Add(payment);
        trip.Status = "completed";
        _db.SaveChanges();

        return Ok(payment);
    }

    [HttpGet("by-trip/{tripId}")]

    public IActionResult GetByTrip(int tripId)
    {
        return Ok(_db.Payments.Where(p => p.TripID == tripId).ToList());
    }
}
