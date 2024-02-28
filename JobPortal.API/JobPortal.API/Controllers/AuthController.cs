using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using JobPortal.API.Services.Implementation;
using JobPortal.API.Services.Interface;
namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly TokenService _tokenService;
        private readonly IRegistrationService _registrationService;
        public AuthController(TokenService tokenService, IRegistrationService registrationService )
        {
            _tokenService = tokenService;    
            _registrationService = registrationService; 
        }

       

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLoginModel user)
        {
            IActionResult response = Unauthorized();
            var token = _tokenService.AuthenticUser(user);
            if (token != null)
            {
               
                return  Ok(new { token = token,User_name =  user.UserName,Statuscode = "done 100" });
            }
            else
            {
                return BadRequest("Invalid User or passWord");
            }
        }
        [Route("Registration")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Registration(UserRegistrationModel user)
        {
            bool response = _registrationService.RegisterUser(user);
            if (response)
            {
                return Ok(new { user = user, });
            }
            else { return BadRequest(new { Message = "Invalid User or Password", });  }
        }



    }
}
