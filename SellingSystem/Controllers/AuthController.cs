using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellingSystem.DTO;
using SellingSystem.Repositories.UserAuthRepository;

namespace SellingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUserAuth _userauth;

        public AuthController(IUserAuth userauth)
        {
            _userauth = userauth;
        }

        [HttpPost("Login")]
        public string Post([FromBody]UserLogin userLogin)
        {
            return _userauth.Login(userLogin);
        }
    }
}
