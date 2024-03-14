using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface IEmployeeProfileService
    {
        public Task<ResponseModel> SetProfileInfo(EmployeeProfileModel profile);
        public Task<ResponseModel> UpdateProfileInfo(EmployeeProfileModel profile);
    }
}
