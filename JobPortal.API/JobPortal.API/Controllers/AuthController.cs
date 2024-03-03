using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobPortal.API.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            var (accessToken, refreshToken) = await _tokenService.AuthenticateUser(user);

            // Return both access and refresh tokens to the client
            return Ok(new { accessToken, refreshToken });
        }

        [Route("refresh-token")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            try
            {
                var newAccessToken = await _tokenService.RefreshToken(refreshToken);
                return Ok(new { accessToken = newAccessToken });
            }
            catch (SecurityTokenException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
