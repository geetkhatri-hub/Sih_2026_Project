namespace SIH_2026.Models
{
    public class Dispute
    {
        public int ID { get; set; }
        public int TripId { get; set; }
        public string Category { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = "submitted";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
