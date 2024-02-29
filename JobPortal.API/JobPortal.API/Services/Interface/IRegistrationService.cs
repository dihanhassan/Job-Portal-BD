using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Services.Interface
{
    public interface IRegistrationService
    {
        public  Task<bool> RegisterUser (UserRegistrationModel user);
    }
}
