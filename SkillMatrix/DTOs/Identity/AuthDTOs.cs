using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SkillMatrix.Application.DTOs.Identity
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "The field {0} is obligatory")]
        [EmailAddress(ErrorMessage = "The field {0} is in wrong format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The field {0} is obligatory")]
        [StringLength(100, ErrorMessage = "The field {0} must has between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Unmatching passwords")]
        public string PasswordConfirmation { get; set; }
    }

    public class LoginUser
    {
        [Required(ErrorMessage = "The field {0} is obligatory")]
        [EmailAddress(ErrorMessage = "The field {0} is in wrong format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "The field {0} is obligatory")]
        [StringLength(100, ErrorMessage = "The field {0} must has between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

    }

    public class UserLoginResponse
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }

    }

    public class UserToken
    {
        private UserToken(string id, string email, IEnumerable<UserClaim> claims)
        {
            Id = id;
            Email = email;
            Claims = claims;
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserClaim> Claims { get; set; }

        public static UserToken Create(User user, IList<Claim> claims)
        {
            var userClaims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value });
            return new UserToken(user.Id, user.Email, userClaims);

        }

    }

    public class UserClaim
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
