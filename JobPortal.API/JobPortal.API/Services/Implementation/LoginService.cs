using JobPortal.API.Models.Authentication;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _repo;
        public LoginService
        (
            ILoginRepo repo
        )
        {
            _repo = repo;
        }
        public async Task<string> GetUserLoginInfo(UserLoginModel user)
        {
            UserLoginModel response;

            response = await _repo.GetUserLoginInfo();

            if (response == null)
            {
                return "Invalid user or password";
            }
            else
            {
                return "Login Success";
            }
        }


    }
}
