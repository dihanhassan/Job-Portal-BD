using JobPortal.API.Models;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class JobApplyService : IJobApplyService
    {
        private readonly IJobApplyRepo _applyRepo;
        public JobApplyService(IJobApplyRepo applyRepo)
        {
            _applyRepo = applyRepo;
        }
        public async Task<ResponseModel> JobApply(JobApplyModel jobApply)
        {
           ResponseModel response = new ResponseModel();
            int RowEffect =await _applyRepo.JobApply(jobApply);
            if (RowEffect > 0)
            {
                response.StatusMessage = "Apply Successfully";
                response.StatusCode = 200;
            }
            else
            {
                response.StatusMessage = "Apply Failed!!";
                response.StatusCode = 100;
            }
            return response;    
        }
    }
}
