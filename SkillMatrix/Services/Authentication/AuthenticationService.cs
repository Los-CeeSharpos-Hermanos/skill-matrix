using Microsoft.AspNetCore.Identity;
using SkillMatrix.Application.DTOs.Identity;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> CreateNewUser(RegisterUser registerUser);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;

        public AuthenticationService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateNewUser(RegisterUser registerUser)
        {
            var user = new User
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
                SurName = registerUser.SurName,
                FirstName = registerUser.FirstName,
                ImageUrl = "abd"
            };

            return await _userManager.CreateAsync(user, registerUser.Password);
        }
    }
}
