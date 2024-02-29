using JobPortal.API.Models.Authentication;
using JobPortal.API.Repositorie.Interface;
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
        public async Task< bool> RegisterUser(UserRegistrationModel user)
        {
            int  response = await _registrationRepo.RegisterUser(user);
            if(response > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
