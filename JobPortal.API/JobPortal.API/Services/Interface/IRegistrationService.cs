using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Services.Interface
{
    public interface IRegistrationService
    {
        public bool RegisterUser (UserRegistrationModel user);
    }
}
