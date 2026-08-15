
namespace SIH_2026.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int TripID { get; set; }
        public decimal AmountPaid { get; set; }
        public string Method { get; set; } = "cash";
        public DateTime paidAt { get; set; } = DateTime.UtcNow;

    }
}
