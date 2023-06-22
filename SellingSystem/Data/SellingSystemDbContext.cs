using Microsoft.EntityFrameworkCore;
using SellingSystem.Models;

namespace SellingSystem.Data
{
    public class SellingSystemDbContext : DbContext
    {
        public SellingSystemDbContext(DbContextOptions<SellingSystemDbContext> context) : base(context)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders {  get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ReturningInvoice> ReturningInvoices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Product>().HasData
                (
                new Product
                {
                    Id = 1,
                    Name = "Chocolate",
                    Price = 2.50M
                },
                new Product
                {
                    Id = 2,
                    Name = "Water",
                    Price = 1
                },
                new Product
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 0.70M
                }
                );
            modelbuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = 1,
                        FirstName = "Ferhad",
                        LastName = "Elizade",
                        Password = "TheBestAdmin",
                        Role = "Admin"
                    }
                );
        }
    }
}
