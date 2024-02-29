using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Services.Interface
{
    public interface ILoginService
    {
        public Task<string> GetUserLoginInfo(UserLoginModel user);
    }
}
