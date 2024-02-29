using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface IRegistrationService
    {
        public  Task<ResponseModel> RegisterUser (UserRegistrationModel user);
    }
}
