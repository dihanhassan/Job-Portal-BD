using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Repositorie.Interface
{
    public interface IRegistrationRepo
    {
        public  Task<int> RegisterUser(UserRegistrationModel user);
    }
}
