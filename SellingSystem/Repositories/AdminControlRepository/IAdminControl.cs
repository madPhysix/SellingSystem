using SellingSystem.Models;

namespace SellingSystem.Repositories.AdminControlRepository
{
    public interface IAdminControl
    {
        public List<User> GetAllUsers();
        public void AddCashier(string firstName, string lastName, string password);
        public void ChangeCashier(int id, string? firstName, string? lastName, string? password);
        public void DeleteCashier(int id);
        public List<Discount> GetAllDiscounts();
        public List<Discount> GetActiveDiscounts();
        public void AddDiscount(DateTime startTime,  DateTime endTime, double percent);
        public void ChangeDiscount(int id,DateTime? startTime,  DateTime? endTime, double? percent);
        public void DeleteDiscount(int id);
        public IEnumerable<Product> GetAllProducts();
        public void AddProduct(Product product);
        public void ChangeProduct(int id, string? name, decimal? price);
        public void DeleteProduct(int id);
    }
}
