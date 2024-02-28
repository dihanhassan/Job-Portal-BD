using JobPortal.API.Models.Authentication;
using JobPortal.API.Repositorie.Interface.Authentication;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepo _registrationRepo;
        public RegistrationService(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }
        public bool RegisterUser(UserRegistrationModel user)
        {
            int  response = _registrationRepo.RegisterUser(user);
            if(response > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
