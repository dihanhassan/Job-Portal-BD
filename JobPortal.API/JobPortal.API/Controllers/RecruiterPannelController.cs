using JobPortal.API.Models;
using JobPortal.API.Repositorie.Interface;
using JobPortal.API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterPannelController : ControllerBase
    {
        private readonly IJobPostService _jobPostService;
        private readonly IViewApplicantService _viewApplicantService;
        public RecruiterPannelController
        (
            IJobPostService jobPostService,
            IViewApplicantService viewApplicantService
        )
        {
            _jobPostService = jobPostService;    
            _viewApplicantService = viewApplicantService;   

        }


        [HttpGet]
        [Route("GetCreatedPost")]
        public async Task<IActionResult> GetCreatedPost(string UserID)
        {
            IActionResult response = Unauthorized();

            return Ok(await _jobPostService.GetJobPostsByUserID(UserID));
        }

        [HttpPut]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int PostID)
        {
            IActionResult response = Unauthorized();
            return Ok(await _jobPostService.DeletePost(PostID));

        }
        [HttpGet]
        [Route("GetApplicantInfo")]
        public async Task<IActionResult> GetApplicantInfo(string UserID, int PostID)
        {
            IActionResult response = Unauthorized();

            return Ok(await _viewApplicantService.GetApplicantInfo(UserID, PostID));
           
        }

    }
}
