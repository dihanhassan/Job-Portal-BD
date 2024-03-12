using JobPortal.API.Models;
using JobPortal.API.Models.Response;

namespace JobPortal.API.Services.Interface
{
    public interface IJobPostService
    {
        public Task<ResponseModel> AddJobPost(JobPostModel jobPost);
        public Task<ResponseModel> GetJobPosts();
        public Task<ResponseModel> GetJobPostsByUserID(string UserID);
        public Task<ResponseModel> DeletePost (int  PostID);    
    }
}
