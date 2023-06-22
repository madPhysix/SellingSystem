namespace SellingSystem.Models
{
    public class ReturningInvoice
    {
        public int Id { get; set; }
        public int InvoicesId { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
        public decimal Total { get; set; } = 0;
    }
}
