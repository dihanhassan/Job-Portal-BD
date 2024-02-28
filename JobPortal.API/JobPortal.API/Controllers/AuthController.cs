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
namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly TokenService _tokenService;
        public AuthController(TokenService tokenService )
        {
           _tokenService = tokenService;    
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
               
                return  Ok(new { token = token,msg="hello",Statuscode = "done 100" });
            }
            else
            {
                return BadRequest(new {message="Invalid credentials"});
            }
        }



    }
}
