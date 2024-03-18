using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Log;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;

namespace JobPortal.API.Services.Implementation
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepo _repo;
        private readonly ILogRepo _logRepo;
        public JobPostService(IJobPostRepo repo,ILogRepo logRepo)
        {
            _repo = repo;   
            _logRepo = logRepo;
        }
    
        public async Task<ResponseModel> AddJobPost(JobPostModel jobPost)
        {
            ResponseModel response = new ResponseModel();

            try
            {
                int rowEffect = await _repo.AddJobPost(jobPost);
               
                if (rowEffect > 0)
                {
                    response.StatusMessage = "Add Post Successfully.";
                    response.StatusCode = 200;

                    CustomLog log = new CustomLog
                    {
                        UserID = jobPost.UserID,
                        ActionTime = DateTime.UtcNow,
                        ActionType = "Insert",
                        ActionField = "Add Post",
                        jsonPayload = JsonSerializer.Serialize(jobPost)
                    };
                    await _logRepo.CreateLog(log);
                }
                else
                {
                    response.StatusMessage = "Post Added Successfully.";
                    response.StatusCode = 200;
                }
                return response;

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<ResponseModel> GetJobPosts()
        {
            
            try
            {
                ResponseModel response = new ResponseModel();
                List<JobPostModel> post = await _repo.GetJobPosts();
                if (post.Count > 0)
                {
                    response.GetJobPosts = post;

                    response.StatusMessage = "post get successfully!";
                    response.StatusCode = 200;

                }
                else
                {
                    response.StatusMessage = "No Data Found";
                    response.StatusCode = 100;
                }
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public async Task<ResponseModel> GetJobPostsByUserID(string UserID)
        {

            try
            {
                ResponseModel response = new ResponseModel();
                List<JobPostModel> post = await _repo.GetJobPostsByUserID(UserID);
                if (post.Count > 0)
                {
                    response.GetJobPosts = post;

                    response.StatusMessage = "post get successfully!";
                    response.StatusCode = 200;

                }
                else
                {
                    response.StatusMessage = "No Data Found";
                    response.StatusCode = 100;
                }
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        public async Task<ResponseModel> DeletePost(int PostID)
        {
            try
            {
                ResponseModel response = new ResponseModel();
                
                if (await _repo.DeletePost(PostID) > 0)
                {
                    
                    response.StatusMessage = "Post deleted successfully!";
                    response.StatusCode = 200;

                }
                else
                {
                    response.StatusMessage = "Get error to delete";
                    response.StatusCode = 100;
                }
                return response;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
