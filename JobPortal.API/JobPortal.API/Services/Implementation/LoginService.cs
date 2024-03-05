using JobPortal.API.Models.Authentication;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;
using JobPortal.API.Models.Response;
using JobPortal.API.Middleware;
namespace JobPortal.API.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _repo;
        private CustomAuth _tokenService;
        public LoginService
        (
            ILoginRepo repo, 
            CustomAuth tokenService

        )
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        public async Task<ResponseModel> GetUserLoginInfo(UserLoginModel user)
        {
            

            ResponseModel response = new ResponseModel();

            UserLoginModel credential = await _repo.GetUserLoginInfo(user.UserName, user.UserPassword);

            if (credential != null && credential.UserName== user.UserName && credential.UserPassword == user.UserPassword)
            {
                
                user.UserID = credential.UserID;
                var token = await _tokenService.AuthenticUser(user);
                credential.AccessToken = token.AcessToken;
                credential.RefreshToken = token.RefreshToken;
               
                credential.UserPassword = null;
                response.UserLogin = credential;
                response.StatusMessage = $"Login Success . Hello Mr. {user.UserName} ";
                response.StatusCode = 200 ;
                
                return response;


            }
            else
            {
                response.StatusMessage = $"Login Faield .";
                response.StatusCode = 100;
                response.UserLogin = credential;
                return response;
            }
        }


    }
}
