using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SkillMatrix.Application.DTOs.Identity;
using SkillMatrix.Application.Extensions;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services.Authentication
{
    public interface ITokenService
    {
        Task<UserTokenResponse> GenerateJWT(string email);
    }

    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly TokenSettings _tokenSettings;

        public TokenService(UserManager<User> userManager, IOptions<TokenSettings> tokenSettings)
        {
            _userManager = userManager;
            _tokenSettings = tokenSettings.Value;
        }

        public async Task<UserTokenResponse> GenerateJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            var identityClaims = GenerateIdentityClaims(user, claims, userRoles);

            var encodedToken = GenerateToken(identityClaims);

            var response = new UserTokenResponse
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
                Audience = _tokenSettings.ValidAt,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_tokenSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);
            return encodedToken;
        }

        private ClaimsIdentity GenerateIdentityClaims(User user, IList<Claim> claims, IList<string> userRoles)
        {
            AddUserInfoToClaims(user, claims);
            AddTokenInfoToClaims(claims);
            AddUserRolesToClaims(claims, userRoles);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            return identityClaims;
        }

        private void AddUserRolesToClaims(IList<Claim> claims, IList<string> userRoles)
        {
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(type: "role", value: userRole));
            }
        }

        private void AddTokenInfoToClaims(IList<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())); //Token expiration
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)); //Token issue date
        }

        private void AddUserInfoToClaims(User user, IList<Claim> claims)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        }

        private long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

    }
}
