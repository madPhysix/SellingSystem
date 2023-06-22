using Microsoft.IdentityModel.Tokens;
using SellingSystem.Data;
using SellingSystem.DTO;
using SellingSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SellingSystem.Repositories.UserAuthRepository
{
    public class UserAuth:IUserAuth
    {
        private readonly SellingSystemDbContext _context;
        private readonly IConfiguration _config;
        public UserAuth(SellingSystemDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Login(UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                return Generate(user);
            }
            else return "User not found";
        }
        private User Authenticate(UserLogin userLogin)
        { 
                User user = _context.Users
                .Where(u => u.FirstName == userLogin.FirstName && u.LastName == userLogin.LastName && u.Password == userLogin.Password)
                .FirstOrDefault();
                return user;
        }
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddHours(12),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
