using JobPortal.API.Models;

namespace JobPortal.API.Repositorie.Interface
{
    public interface IJobSeekerProfileRepo
    {
        public Task<int> SetProfileInfo(JobSeekerProfileModel profile);
    }
}
