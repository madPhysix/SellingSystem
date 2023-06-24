using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SellingSystem.Data;
using SellingSystem.Models;

namespace SellingSystem.Repositories.InvoiceControlRepository
{
    
    public class InvoiceControl:IInvoiceControl
    {
        private readonly SellingSystemDbContext _context;
        public InvoiceControl(SellingSystemDbContext context)
        {
            _context = context;
        }
        public Result CreateInvoice(IEnumerable<Order> orders)
        {
            decimal total = 0;

            foreach(var order in orders)
            {
                if (!_context.Products.Any(p => p.Id == order.ProductId))
                    return new Result { Message = "This product is not available in our store or it doesn't exist" };
                total += Decimal.Multiply(_context.Products.Find(order.ProductId).Price, order.Amount);
            }
            var discount  = _context.Discounts
                .Where(d => d.EndOfDiscount > DateTime.Now && d.StartOfDiscount < DateTime.Now && d.IsActive == true)
                .FirstOrDefault();
            if(discount != null)
            {
                total = Decimal.Multiply(total, (decimal)(1 - (discount.DiscountPercent)/100));
            }

            Invoice invoice = new Invoice() { Orders = orders, Total = total };
            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            return new Result { Data = invoice, Message = "Success"};
        }


        public Result CreateReturningInvoice(ReturningInvoice retInvoice)
        {
            var invoiceProducts = _context.Invoices.Where(i => i.Id == retInvoice.InvoicesId).SelectMany(i => i.Orders, (i, o) => o.Product).ToList();
            if (invoiceProducts != null)
            {
                var productIds = retInvoice.Orders.Select(p => p.ProductId).ToList();
                if (invoiceProducts.SequenceEqual(_context.Products.Where(p => productIds.Contains(p.Id))))
                {

                    _context.ReturningInvoices.Add(retInvoice);
                    _context.SaveChanges();


                    return new Result() { Data = retInvoice, Message = "Success" };
                }
            }
                return new Result() { Message = "Couldn't find corresponding invoice" };
        }
    }
}
