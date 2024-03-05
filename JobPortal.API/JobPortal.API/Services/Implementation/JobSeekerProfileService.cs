using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Data;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Implementation;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class JobSeekerProfileService : IJobSeekerProfileService
    {
        private readonly IJobSeekerProfileRepo _jobSeekerProfileRepo;
        public JobSeekerProfileService(IJobSeekerProfileRepo jobSeekerProfileRepo)
        {
           _jobSeekerProfileRepo = jobSeekerProfileRepo;
            
        }
        public async Task<ResponseModel> SetProfileInfo(JobSeekerProfileModel profile)
        {
            ResponseModel response = new ResponseModel();

            int RowsCount = await _jobSeekerProfileRepo.SetProfileInfo(profile);
           
            if (RowsCount > 0)
            {
                response.StatusMessage = $"Profile Created Successfully ";
                response.StatusCode = 200;
                return response;
            }
            else
            {
                response.StatusMessage = $"Profile Create Failed";
                response.StatusCode = 100;
                return response;

            }



            return  response;

        }
    }
}
