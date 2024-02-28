using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortal.API.Models;
using JobPortal.API.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private  UserLoginModel AuthenticUser(UserLoginModel user)
        {
            UserLoginModel _actualUser = new UserLoginModel();

            UserLoginModel  _user = null;
            _actualUser.UserName = "xyz";
            _actualUser.Password = "123";

            if(user.UserName== _actualUser.UserName && user.Password == _actualUser.Password)
            {
                _user = user;
            }
            return _user;
        }
        private string GenerateToken (UserLoginModel user)
        {
            var security_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials (security_key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],null,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credential

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserLoginModel user)
        {
            IActionResult response = Unauthorized();
            var _user = AuthenticUser(user);
            if (_user != null)
            {
                var token = GenerateToken(_user);
                return  Ok(new { token = token,msg="hello",Statuscode = "done 100" });
            }
            else
            {
                return BadRequest(new {message="Invalid credentials"});
            }
        }



    }
}
