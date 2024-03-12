using JobPortal.API.Models;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface IJobApplyService
    {
        public Task<ResponseModel> JobApply(JobApplyModel jobApply);
    }
}
