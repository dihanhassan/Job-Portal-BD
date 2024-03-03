using JobPortal.API.Models.Authentication;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;
using JobPortal.API.Models.Response;
using System.Threading.Tasks;

namespace JobPortal.API.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _repo;
        private readonly TokenService _tokenService;

        public LoginService(ILoginRepo repo, TokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public async Task<ResponseModel> GetUserLoginInfo(UserLoginModel user)
        {
            ResponseModel response = new ResponseModel();

            UserLoginModel credential = await _repo.GetUserLoginInfo(user.UserName, user.UserPassword);

            if (credential != null && credential.UserName == user.UserName && credential.UserPassword == user.UserPassword)
            {
                var (accessToken, refreshToken) = await _tokenService.AuthenticateUser(credential);
                credential.UserPassword = null;

                response.UserLogin = credential;
                response.StatusMessage = $"Login Success. Hello Mr. {user.UserName}";
                response.StatusCode = 200;
                response.AccessToken = accessToken;
                response.RefressToken = refreshToken;

                return response;
            }
            else
            {
                response.StatusMessage = $"Login Failed.";
                response.StatusCode = 100;
                response.UserLogin = credential;
                return response;
            }
        }
    }
}
