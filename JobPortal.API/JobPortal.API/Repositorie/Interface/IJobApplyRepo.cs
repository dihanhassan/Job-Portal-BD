using JobPortal.API.Models;

namespace JobPortal.API.Repositorie.Interface
{
    public interface IJobApplyRepo
    {
        public Task<int> JobApply (JobApplyModel model);
    }
}
