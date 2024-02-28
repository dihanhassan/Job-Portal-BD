using JobPortal.API.Services.Implementation;
using JobPortal.API.Models.Data;
using JobPortal.API.Services.Implementation;
using JobPortal.API.Services.Interface;
using JobPortal.API.Repositorie.Implimentation;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Repositorie.Interface.Authentication;
using JobPortal.API.Repositorie.Implimentation.Authentication;
namespace JobPortal.API
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddTransient<TokenService, TokenService>();
            Services.AddTransient<DapperDBConnection>();

            Services.AddTransient<IRegistrationService, RegistrationService>();
            Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
        }
    }
}
