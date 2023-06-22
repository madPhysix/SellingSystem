using SellingSystem.DTO;

namespace SellingSystem.Repositories.UserAuthRepository
{
    public interface IUserAuth
    {
        public string Login(UserLogin userLogin);
    }
}
