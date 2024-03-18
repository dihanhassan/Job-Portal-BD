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
        public async Task< string> AuthenticUser(UserLoginModel user)
        {
           
            
              return await  GenerateToken(user);
           
            
        }
        private async Task< string> GenerateToken(UserLoginModel user)
        {

            var security_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials(security_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], null,
                    expires: DateTime.Now.AddMinutes(1),
                    signingCredentials: credential

                );

            return  new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
