﻿using JobPortal.API.Services.Implementation;
using JobPortal.API.Models.Data;
using JobPortal.API.Services.Implementation;
using JobPortal.API.Services.Interface;
using JobPortal.API.Repositorie;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Repositorie.Implementation;
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
            Services.AddTransient<ILoginRepo, LoginRepo>();
            Services.AddTransient<ILoginService, LoginService>();
        }
    }
}
