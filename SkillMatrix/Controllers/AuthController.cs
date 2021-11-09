using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkillMatrix.Application.DTOs.Identity;
using SkillMatrix.Application.Extensions;
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
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _tokenSettings;

        public AuthController(
             SignInManager<User> signInManager,
             UserManager<User> userManager,
             IOptions<TokenSettings> tokenSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenSettings = tokenSettings.Value;
        }

        [HttpPost("new-account")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new User
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return CustomResponse(await GenerateJWT(registerUser.Email));
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
                return CustomResponse(await GenerateJWT(loginUser.Email));
            }

            if (result.IsLockedOut)
            {
                AddProcessingError("Too many invalid attempts to login. The user is temporaly blocked");
                return CustomResponse();
            }

            AddProcessingError("Incorrect password or user");

            return CustomResponse();
        }

        private async Task<UserLoginResponse> GenerateJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var identityClaims = GenerateIdentityClaims(user, claims, userRoles);

            var encodedToken = GenerateToken(identityClaims);

            var response = new UserLoginResponse
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_tokenSettings.ExpirationHours).TotalSeconds,
                UserToken = UserToken.Create(user, claims)
            };

            return response;
        }

        private string GenerateToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenSettings.Issuer,
                Audience = _tokenSettings.ValidIn,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_tokenSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        private static ClaimsIdentity GenerateIdentityClaims(User user, IList<Claim> claims, IList<string> userRoles)
        {
            AddUserInfoToClaims(user, claims);
            AddTokenInfoToClaims(claims);
            AddUserRolesToClaims(claims, userRoles);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            return identityClaims;
        }

        private static void AddUserRolesToClaims(IList<Claim> claims, IList<string> userRoles)
        {
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(type: "role", value: userRole));
            }
        }

        private static void AddTokenInfoToClaims(IList<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())); //Token expiration
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)); //Token issue date
        }

        private static void AddUserInfoToClaims(User user, IList<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);



    }
}
