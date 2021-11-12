using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.Domain.Users.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _db;


        public UserRepository(UserManager<User> userManager, ApplicationDBContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userManager.Users
                                  .OrderBy(u => u.SurName)
                                  .ToListAsync();
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> CreateUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            var languageRatings = await _db.LanguageRatings.Where(l => l.UserId == user.Id).ToListAsync();
            foreach (LanguageRating l in languageRatings)
            {
                _db.LanguageRatings.Remove(l);
            }

            var skillRatings = await _db.SkillRatings.Where(s => s.UserId == user.Id).ToListAsync();
            foreach (SkillRating s in skillRatings)
            {
                _db.SkillRatings.Remove(s);
            }

            var testc = await _userManager.UpdateAsync(user);

            return testc;
        }

        public async Task<IdentityResult> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.DeleteAsync(user);
        }
    }
}
