using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkillMatrix.Application.DTOs.Identity;
using SkillMatrix.Application.Extensions;
using SkillMatrix.Application.Services.Authentication;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;


        public AuthController(
            SignInManager<User> signInManager,
            IAuthenticationService authenticationService,
            ITokenService tokenService)
        {
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _authenticationService.CreateNewUser(registerUser);

            if (result.Succeeded)
            {
                return CustomResponse(await _tokenService.GenerateJWT(registerUser.Email));
            }

            foreach (var error in result.Errors)
            {
                AddProcessingError(error.Description);
            }

            return CustomResponse();

        }

        [HttpPost("authenticate")]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse();

            var result = await _signInManager.PasswordSignInAsync(
                    loginUser.Email,
                    password: loginUser.Password,
                    isPersistent: false,
                    lockoutOnFailure: true);

            //lockoutOnFailure: lock the loging in the application for an amount of time if there were too many failed logins attempts. 
            if (result.Succeeded)
            {
                return CustomResponse(await _tokenService.GenerateJWT(loginUser.Email));
            }

            if (result.IsLockedOut)
            {
                AddProcessingError("Too many invalid attempts to login. The user is temporaly blocked");
                return CustomResponse();
            }

            AddProcessingError("Incorrect password or user");

            return CustomResponse();
        }
    }
}
