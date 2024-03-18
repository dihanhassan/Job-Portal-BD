using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Response;
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
        public async Task< ResponseModel> RegisterUser(UserRegistrationModel user)
        {
            int  RowsCount= await _registrationRepo.RegisterUser(user);
            ResponseModel response = new ResponseModel();
            if(RowsCount > 0)
            {
                response.StatusMessage = $"Login Success . Hello Mr. {user.UserName} ";
                response.StatusCode = 200;
                return response;
            }
            else 
            {
                response.StatusMessage = $"Login Faield .";
                response.StatusCode = 100;
                return response;

            }
        }
    }
}
