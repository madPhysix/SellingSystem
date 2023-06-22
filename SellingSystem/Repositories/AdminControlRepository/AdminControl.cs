using Microsoft.AspNetCore.Authorization;
using SellingSystem.Data;
using SellingSystem.Models;

namespace SellingSystem.Repositories.AdminControlRepository
{
    
    public class AdminControl : IAdminControl
    {
        private readonly SellingSystemDbContext _context;
        public AdminControl(SellingSystemDbContext context)
        {
            _context = context;
        }
        public void AddCashier(string firstName, string lastName, string password)
        {
            User user = new User(firstName, lastName, password);
            _context.Add(user);
            _context.SaveChanges();
        }

        public void ChangeCashier(int id, string? firstName, string? lastName, string? password)
        {
            var changingUser = _context.Users.Find(id);
            if (firstName != null)
                changingUser.FirstName = firstName;
            if (lastName != null)
                changingUser.LastName = lastName;
            if (password != null)
                changingUser.Password = password;
            _context.Users.Update(changingUser);
            _context.SaveChanges();
        }


        public void DeleteCashier(int id)
        {
            var firedCashier = _context.Users.Find(id);
            firedCashier.Role = "Deactivated";
            _context.Users.Update(firedCashier);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users
            .Select(u => new User { Id = u.Id, FirstName = u.FirstName, LastName = u.LastName, Role = u.Role }).ToList();
        }

        public List<Discount> GetAllDiscounts()
        {
            return _context.Discounts.ToList();
        }

        public List<Discount> GetActiveDiscounts()
        {
            return _context.Discounts
                .Where(d => d.IsActive && d.EndOfDiscount > DateTime.Now && d.StartOfDiscount < DateTime.Now)
                .ToList();
        }

        public void AddDiscount(DateTime start, DateTime end, double percent)
        {
            Discount discount = new Discount() { StartOfDiscount = start, EndOfDiscount = end, DiscountPercent = percent };
            _context.Discounts.Add(discount);
            _context.SaveChanges();
        }

        public void ChangeDiscount(int id,DateTime? startTime, DateTime? endTime, double? percent)
        {
            var changingDiscount = _context.Discounts.Find(id);
            if (startTime != null)
                changingDiscount.StartOfDiscount = (DateTime)startTime;
            if (endTime != null)
                changingDiscount.EndOfDiscount = (DateTime)endTime;
            if (percent != null)
                changingDiscount.DiscountPercent = (double)percent;
            _context.Discounts.Update(changingDiscount);
            _context.SaveChanges();
        }

        public void DeleteDiscount(int id)
        {
            var deletedDiscount = _context.Discounts.Find(id);
            deletedDiscount.IsActive = false;
            _context.Discounts.Update(deletedDiscount);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetAvailableProducts()
        {
            return _context.Products.Where(p => p.IsAvailable).ToList();
        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void ChangeProduct(int id, string? name, decimal? price)
        {
            var changingProduct = _context.Products.Find(id);
            if (name != null)
                changingProduct.Name = name;
            if (price != null)
                changingProduct.Price = (decimal)price;
            _context.Products.Update(changingProduct); 
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var deletingProduct = _context.Products.Find(id);
            deletingProduct.IsAvailable = false;
            _context.Products.Update(deletingProduct);
            _context.SaveChanges();
        }
    }
}
