using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellingSystem.Models;
using SellingSystem.Repositories.InvoiceControlRepository;

namespace SellingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier, Admin")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceControl _invoiceControl;
        public InvoiceController(IInvoiceControl invoiceControl)
        {
            _invoiceControl = invoiceControl;
        }

        [HttpPost("Create Invoice")]
        public Result CreateInvoice(IEnumerable<Order> orders)
        {
            return _invoiceControl.CreateInvoice(orders);
        }

        [HttpPost("Create Returning Invoice")]
        public Result CreateReturningInvoice(ReturningInvoice retInvoice)
        {
            return _invoiceControl.CreateReturningInvoice(retInvoice);
        }
    }
}
