using JobPortal.API.Services.Implementation;

namespace JobPortal.API
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddTransient<TokenService, TokenService>();
            
        }
    }
}
