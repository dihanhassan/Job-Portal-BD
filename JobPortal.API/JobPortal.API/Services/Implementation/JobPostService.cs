﻿using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using JobPortal.API.Models.Response;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;

namespace JobPortal.API.Services.Implementation
{
    public class JobPostService : IJobPostService
    {
        private readonly IJobPostRepo _repo;
        public JobPostService(IJobPostRepo repo)
        {
            _repo = repo;   
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


    }
}