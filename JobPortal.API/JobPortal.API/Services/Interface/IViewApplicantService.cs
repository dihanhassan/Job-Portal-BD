using JobPortal.API.Models;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface IViewApplicantService
    {
        public Task<ResponseModel> GetApplicantInfo(string UserID, int PostID);
    }
}
