using JobPortal.API.Models;

namespace JobPortal.API.Repositorie.Interface
{
    public interface IJobPostRepo
    {
        public Task<int> AddJobPost (JobPostModel jobPost);
        public Task<List<JobPostModel>> GetJobPosts();
    }
}
