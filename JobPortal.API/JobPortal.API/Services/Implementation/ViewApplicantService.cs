using JobPortal.API.Models;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class ViewApplicantService : IViewApplicantService
    {
        private readonly IViewApplicantRepo _view;
        public ViewApplicantService(IViewApplicantRepo view)
        {
            _view = view;        
        }

        public async Task<ResponseModel> GetApplicantInfo(string UserID, int PostID)
        {
           ResponseModel response = new ResponseModel();
           
            List<ApplicantInfoModel> applicants =await _view.GetApplicantInfo(UserID, PostID);
            if(applicants.Count>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Get Info Successfully!";
                response.GetApplicantInfo = applicants;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Error to get Info!";
            }
            return response;  
        }
    }
}
