using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SkillMatrix.Application.DTOs.Identity;
using SkillMatrix.Application.Services.Authentication;
using SkillMatrix.Domain.Users.Models;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : MainController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;


        public AuthenticationController(
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

        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return CustomResponse();
        }
    }
}
