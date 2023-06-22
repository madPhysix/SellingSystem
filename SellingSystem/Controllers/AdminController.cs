using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SellingSystem.Models;
using SellingSystem.Repositories.AdminControlRepository;

namespace SellingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminControl _control;
        public AdminController(IAdminControl control)
        { 
            _control = control;
        }
        [HttpGet("Get All Users")]
        public IEnumerable<User> GetAllUsers()
        {
            return _control.GetAllUsers();
        }

        [HttpGet("Get All Discounts")]
        public List<Discount> GetAllDiscounts()
        {
            return _control.GetAllDiscounts();
        }

        [HttpGet("Get Active Discounts")]
        public List<Discount> GetActiveDiscounts()
        {
            return _control.GetActiveDiscounts();
        }

        [HttpGet("Get All Products")]
        public IEnumerable<Product> GetAllProducts()
        {
            return _control.GetAllProducts();
        }

        [HttpPost("Add Cashier")]
        public void AddCashier(string firstName, string lastName, string password)
        {
            _control.AddCashier(firstName, lastName, password);
        }

        [HttpPost("Add Discount")]
        public void AddDiscount(DateTime startTime, DateTime endTime, double percent)
        {
            _control.AddDiscount(startTime, endTime, percent);
        }
        [HttpPost("Add Product")]
        public void AddProduct(Product product)
        {
            _control.AddProduct(product);
        }

        [HttpPut("Change Cashier")]
        public void ChangeCashier(int id, string? firstName, string? lastName, string? password)
        {
            _control.ChangeCashier(id, firstName, lastName, password);
        }

        [HttpPut("Change Discount")]
        public void ChangeDiscount(int id, DateTime? startTime, DateTime? endTime, double? percent)
        {
            _control.ChangeDiscount(id,  startTime, endTime, percent);
        }

        [HttpPut("Change Product")]
        public void ChangeProduct(int id, string? name, decimal? price)
        {
            _control.ChangeProduct(id, name, price);
        }

        [HttpDelete("Delete Cashier")]
        public void DeleteCashier(int id)
        {
            _control.DeleteCashier(id);
        }

        [HttpDelete("Delete Discount")]
        public void DeleteDiscount(int id)
        {
            _control.DeleteDiscount(id);
        }

        [HttpDelete("Delete Product")]
        public void DeleteProduct(int id)
        {
            _control.DeleteProduct(id);
        }
    }
}
