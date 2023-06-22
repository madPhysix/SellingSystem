namespace SellingSystem.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public double DiscountPercent { get; set; }
        public DateTime StartOfDiscount { get; set; }
        public DateTime EndOfDiscount { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
