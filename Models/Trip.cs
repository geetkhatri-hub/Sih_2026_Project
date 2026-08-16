namespace SIH_2026.Models
{
    public class Trip
    {
        public int ID { get; set; }
        public int ProviderID { get; set; }
        public string Origin { get; set; } = "";
        public string Destination { get; set; } = "";
        public double DistanceKm { get; set; }
        public decimal AgreedFare { get; set; }
        public string Status { get; set; } = "Confirmed";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
