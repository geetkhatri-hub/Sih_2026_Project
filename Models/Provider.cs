using SIH_2026.Data;
using Microsoft.EntityFrameworkCore;
namespace SIH_2026.Models
{
    public class Provider
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string VehicalType { get; set; } = "";
        public string VehicalNumber { get; set; } = "";
        public string VerificationStatus { get; set; } = "pending";
        public double Score { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? QrPayload { get; set; }
    }
}
