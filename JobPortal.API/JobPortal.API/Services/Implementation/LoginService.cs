using JobPortal.API.Models.Authentication;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _repo;
        private TokenService _tokenService;
        public LoginService
        (
            ILoginRepo repo, 
            TokenService tokenService

        )
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        public async Task<string> GetUserLoginInfo(UserLoginModel user)
        {
            UserLoginModel response;
            
            response = await _repo.GetUserLoginInfo();

            if (response!=null && response.UserName== user.UserName && response.UserPassword == user.UserPassword)
            {
                string token = await _tokenService.AuthenticUser(user);
               
                return "Login Success. GUID = "+response.UserID +"  Token : "+token;
            }
            else
            {
                return "Invalid user or password";
            }
        }


    }
}
