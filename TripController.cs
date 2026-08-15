using Microsoft.AspNetCore.Mvc;
using SIH_2026.Data;
using SIH_2026.Models;

namespace SIH_2026.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TripController:ControllerBase
{
    private readonly AppDbContext _db;
    public TripController(AppDbContext db)
    {
        _db = db;
    }
    [HttpPost]
    public IActionResult Create(Trip trip)
    {
        trip.Status = "Confirmed";
        _db.Trips.Add(trip);
        _db.SaveChanges();
        return Ok(trip);
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_db.Trips.ToList());
    }
    [HttpGet("fare-history")]
    public IActionResult GetFareHistory(int providerId, string destination)
    {
        var trips = _db.Trips
            .Where(t => t.ProviderID == providerId && t.Destination == destination && t.Status == "completed")
            .Join(_db.Payments, t => t.ID, p => p.TripID, (t, p) => new { 
                t.ID,
                t.Origin,
                t.Destination,
                AmountPaid = p.AmountPaid,
                Method = p.Method,
                PaidAt = p.paidAt})
            .OrderByDescending(x=>x.PaidAt)
            .Take(5)
            .ToList();
        var average = trips.Any() ? trips.Average(h=>h.AmountPaid) : 0;
        return Ok(new
        {
            Average = average,
            RecentTrip=trips
        });
    } 
}
