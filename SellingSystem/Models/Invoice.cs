namespace SellingSystem.Models
{
    public class Invoice
    {
        public int Id { get; set; } = 0;
        public IEnumerable<Order>? Orders { get; set; }
        public decimal Total { get; set; } = 0;
    }
}
