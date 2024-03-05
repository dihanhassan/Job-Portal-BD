using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface IJobSeekerProfileService
    {
        public Task<ResponseModel> SetProfileInfo(JobSeekerProfileModel profile);
    }
}
