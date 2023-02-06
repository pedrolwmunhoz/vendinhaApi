namespace vendinhaApi.Models
{
    public class SaleList
    {
        public int ClientId { get; set; }
        public int SaleListId { get; set; }
        public double Value { get; set; }
        public bool IsPaid { get; set; }
        public string CreationDate { get; set; } = string.Empty;
        public string PaymentDate { get; set; } = string.Empty;
    }
}
