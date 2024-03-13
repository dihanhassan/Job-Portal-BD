using JobPortal.API.Models;
namespace JobPortal.API.Repositorie.Interface
{
    public interface IViewApplicantRepo
    {
        public Task<List<ApplicantInfoModel>> GetApplicantInfo(string UserID, int PostID);
    }
}
