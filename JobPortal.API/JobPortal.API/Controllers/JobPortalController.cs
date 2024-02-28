using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPortalController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetDataByAuth")]
        public string GetDataByAuth()
        {
            return "Data Can be Accessed With Auth";
        }

        
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "Data Can be Accessed Without Auth";
        }

    }
}
