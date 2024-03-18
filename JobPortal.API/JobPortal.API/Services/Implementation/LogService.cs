using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class LogService :ILogService
    {
        private readonly ILogRepo _logRepo;
        public LogService(ILogRepo _logRepo)
        {
            
        }

      
    }
}
