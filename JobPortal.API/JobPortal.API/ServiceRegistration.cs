using JobPortal.API.Services.Implementation;
using JobPortal.API.Models.Data;
using JobPortal.API.Services.Interface;
using JobPortal.API.Repositorie;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Repositorie.Implementation;
using JobPortal.API.Middleware;
namespace JobPortal.API
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddTransient<CustomAuth, CustomAuth>();
            Services.AddTransient<DapperDBConnection>();

            Services.AddTransient<IRegistrationService, RegistrationService>();
            Services.AddTransient<IRegistrationRepo, RegistrationRepo>();
            Services.AddTransient<ILoginRepo, LoginRepo>();
            Services.AddTransient<ILoginService, LoginService>();
            Services.AddTransient<IEmployeeProfileService, EmployeeProfileService>();
            Services.AddTransient<IEmployeeProfileRepo, EmployeeProfileRepo>();
            Services.AddTransient<IJobPostRepo, JobPostRepo>();
            Services.AddTransient<IJobPostService, JobPostService>();
            Services.AddTransient<IJobApplyService, JobApplyService>();
            Services.AddTransient<IJobApplyRepo, JobApplyRepo>();
            Services.AddTransient<IViewApplicantRepo, ViewApplicantRepo>();
            Services.AddTransient<IViewApplicantService, ViewApplicantService>();
            Services.AddTransient<ILogRepo,LogRepo >();


        }
    }
}
