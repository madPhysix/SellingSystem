namespace SellingSystem.Models
{
    public class User
    {
        public User() { }
        public User(string firstName, string lastName, string password) 
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "Cashier";
    }
}
