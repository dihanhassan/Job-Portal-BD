using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Repositorie.Interface
{
    public interface ILoginRepo
    {
        public Task<UserLoginModel> GetUserLoginInfo(string UserName, String UserPassword);
    }
}
