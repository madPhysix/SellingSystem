using SellingSystem.Models;

namespace SellingSystem.Repositories.InvoiceControlRepository
{
    public interface IInvoiceControl
    {
        public Result CreateInvoice(IEnumerable<Order> orders);
        public Result CreateReturningInvoice(ReturningInvoice retInvoice);
    }
}
