﻿using Microsoft.AspNetCore.Http;
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
using JobPortal.API.Models.Response;
namespace JobPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       
        private readonly TokenService _tokenService;
        private readonly IRegistrationService _registrationService;
        private readonly ILoginService _loginService;
        public AuthController
        (
            TokenService tokenService,
            IRegistrationService registrationService,
            ILoginService loginService


        )
        {
            _tokenService = tokenService;    
            _registrationService = registrationService; 
            _loginService = loginService;
        }

       

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel user)
        {
          IActionResult response = Unauthorized();
            
           
           return  Ok(await _loginService.GetUserLoginInfo(user));
            
           
        }
        [Route("Registration")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Registration(UserRegistrationModel user)
        {
            return  Ok( await _registrationService.RegisterUser(user));
       
        }



    }
}
