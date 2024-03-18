using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Data;
using JobPortal.API.Models.Log;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Implementation;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;
using System.Text;
using System.Text.Json;

namespace JobPortal.API.Services.Implementation
{
    public class EmployeeProfileService : IEmployeeProfileService
    {
        private readonly IEmployeeProfileRepo _jobSeekerProfileRepo;
        private readonly ILogRepo _logRepo;
       
        public EmployeeProfileService
        (
            IEmployeeProfileRepo jobSeekerProfileRepo,
            ILogRepo logRepo    
        )
        {
            _jobSeekerProfileRepo = jobSeekerProfileRepo;
            _logRepo = logRepo; 
            
        }
        public async Task<ResponseModel> SetProfileInfo(EmployeeProfileModel profile)
        {
            ResponseModel response = new ResponseModel();

            int RowsCount = await _jobSeekerProfileRepo.SetProfileInfo(profile);
             
            if (RowsCount > 0)
            {

                CustomLog log = new CustomLog {
                    UserID = profile.UserID,
                    ActionTime = DateTime.UtcNow,
                    ActionType = "Insert",
                    ActionField = "Set Profile",
                    jsonPayload = JsonSerializer.Serialize(profile)
                };
                await _logRepo.CreateLog(log);

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



          

        }
        public async Task<ResponseModel> UpdateProfileInfo(EmployeeProfileModel profile)
        {
            ResponseModel response = new ResponseModel();

            int RowsCount = await _jobSeekerProfileRepo.UpdateProfileInfo(profile);

            if (RowsCount > 0)
            {
                CustomLog log = new CustomLog
                {
                    UserID = profile.UserID,
                    ActionTime = DateTime.UtcNow,
                    ActionType = "Update",
                    ActionField = "Update Profile",
                    jsonPayload = JsonSerializer.Serialize(profile)
                };

                await _logRepo.CreateLog(log);

                response.StatusMessage = $"Profile Update Successfully ";
                response.StatusCode = 200;
                return response;
            }
            else
            {
                response.StatusMessage = $"Profile Create Failed";
                response.StatusCode = 100;
                return response;

            }



          

        }
    }
}
