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
        
        public EmployeeController(IEmployeeProfileService jobSeekerProfileService)
        {
            _jobSeekerProfileService = jobSeekerProfileService;
        }

        [Authorize]
        [HttpGet]
        [Route("getDataByAuth")]
        public string GetDataByAuth()
        {
            return "Data Can be Accessed With Auth";
        }

        
        

        [Authorize]
        [HttpPost]
        [Route("SetSeekerProfile")]
        public async Task<IActionResult> SetSeekerProfile(EmployeeProfileModel profile)
        {
            IActionResult response = Unauthorized();


            return Ok(await _jobSeekerProfileService.SetProfileInfo(profile));

        }

      

    }
}
