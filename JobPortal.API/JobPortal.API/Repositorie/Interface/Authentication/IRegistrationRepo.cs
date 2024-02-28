using JobPortal.API.Models.Authentication;

namespace JobPortal.API.Repositorie.Interface.Authentication
{
    public interface IRegistrationRepo
    {
        public int RegisterUser(UserRegistrationModel user);
    }
}
