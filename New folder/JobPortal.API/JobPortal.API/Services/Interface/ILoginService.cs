using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface ILoginService
    {
        public Task<ResponseModel> GetUserLoginInfo(UserLoginModel user);
    }
}
