using JobPortal.API.Models.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<(string accessToken, string refreshToken)> AuthenticateUser(UserLoginModel user)
    {
        var accessToken = GenerateToken(user, TimeSpan.FromMinutes(1)); // Shorter expiry for access token
        var refreshToken = GenerateToken(user, TimeSpan.FromDays(1)); // Longer expiry for refresh token

        return (accessToken, refreshToken);
    }

    public async Task<string> RefreshToken(string refreshToken)
    {
        var principal = GetPrincipalFromToken(refreshToken);
        var userIdClaim = principal?.FindFirst("userId");

        if (userIdClaim == null)
        {
            throw new SecurityTokenException("Invalid refresh token");
        }

        // Here you can validate the refresh token against your database or other storage mechanism
        // For simplicity, we're assuming the refresh token is valid

        var user = new UserLoginModel { UserId = userIdClaim.Value };
        return GenerateToken(user, TimeSpan.FromMinutes(15)); // Refreshed access token with shorter expiry
    }

    private string GenerateToken(UserLoginModel user, TimeSpan expiryTime)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            _configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            new Claim[]
            {
                new Claim("userId", user.UserId),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
            },
            expires: DateTime.Now.Add(expiryTime),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private ClaimsPrincipal GetPrincipalFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        try
        {
            var principal = tokenHandler.ValidateToken(token, validationParameters, out var securityToken);
            if (!IsJwtWithValidSecurityAlgorithm(securityToken))
            {
                throw new SecurityTokenException("Invalid token");
            }
            return principal;
        }
        catch
        {
            return null;
        }
    }

    private TokenValidationParameters GetValidationParameters()
    {
        return new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration["Jwt:Issuer"],
            ValidAudience = _configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]))
        };
    }

    private bool IsJwtWithValidSecurityAlgorithm(SecurityToken securityToken)
    {
        return (securityToken is JwtSecurityToken jwtSecurityToken) &&
            jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
    }
}
