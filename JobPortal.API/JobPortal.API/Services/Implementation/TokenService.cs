using JobPortal.API.Models.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JobPortal.API.Services.Implementation
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string AuthenticUser(UserLoginModel user)
        {
            UserLoginModel _actualUser = new UserLoginModel();

            UserLoginModel _user = null;
            _actualUser.UserName = "xyz";
            _actualUser.Password = "123";

            if (user.UserName == _actualUser.UserName && user.Password == _actualUser.Password)
            {
                return GenerateToken(user);
            }
            else
            {
                return null;
            }
            
        }
        private string GenerateToken(UserLoginModel user)
        {

            var security_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials(security_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], null,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credential

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
