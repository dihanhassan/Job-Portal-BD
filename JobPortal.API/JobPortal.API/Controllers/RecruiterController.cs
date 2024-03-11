using JobPortal.API.Models;
using JobPortal.API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IJobPostService _jobPostService;
        public RecruiterController
        (
            IJobPostService jobPostService
        )
        {
            _jobPostService = jobPostService;   
        }
       
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost(JobPostModel jobPost)
        {
            IActionResult response = Unauthorized();

            return Ok(await _jobPostService.AddJobPost(jobPost));
        }

      
        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            IActionResult response = Unauthorized();


            return Ok(await _jobPostService.GetJobPosts() );

        }


    }
}
