using JobPortal.API.Models;
using JobPortal.API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeProfileService _jobSeekerProfileService;
        private readonly IJobApplyService _jobApplyService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmployeeController
        (
          IEmployeeProfileService jobSeekerProfileService,
          IJobApplyService jobApplyService,
          IWebHostEnvironment webHostEnvironment
        )
        {
            _jobSeekerProfileService = jobSeekerProfileService;
            _jobApplyService = jobApplyService;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        [HttpGet]
        [Route("getDataByAuth")]
        public string GetDataByAuth()
        {
            return "Data Can be Accessed With Auth";
        }

        
        

       
        [HttpPost]
        [Route("SetSeekerProfile")]
        public async Task<IActionResult> SetSeekerProfile(EmployeeProfileModel profile)
        {

            if (profile.Resume != null)
            {
                string folder = "Resume/";
                folder += Guid.NewGuid().ToString() + "-" + profile.Resume.FileName;
                profile.ResumeUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await profile.Resume.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            IActionResult response = Unauthorized();


            return Ok(await _jobSeekerProfileService.SetProfileInfo(profile));

        }
       
        [HttpPost]
        [Route("JobApply")]
        public async Task<IActionResult> JobApply(JobApplyModel jobApply)
        {
            IActionResult response = Unauthorized();


            return Ok(await _jobApplyService.JobApply(jobApply));

        }

        [HttpPut]
        [Route("UpdateSeekerProfile")]
        public async Task<IActionResult> UpdateSeekerProfile (EmployeeProfileModel profile)
        {
            IActionResult response = Unauthorized();

            if (profile.Resume != null)
            {
                string folder = "Resume/";
                folder += Guid.NewGuid().ToString() + "-" + profile.Resume.FileName;
                profile.ResumeUrl = "/" + folder;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await profile.Resume.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            return Ok(await _jobSeekerProfileService.UpdateProfileInfo(profile));
        }

        
        

    }
}
