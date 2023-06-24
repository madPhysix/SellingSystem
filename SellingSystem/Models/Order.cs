using System.ComponentModel.DataAnnotations.Schema;

namespace SellingSystem.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public decimal Amount { get; set; } 
    }
}
