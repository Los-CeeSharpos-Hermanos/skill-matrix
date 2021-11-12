using Microsoft.AspNetCore.Identity;
using SkillMatrix.Domain.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(string id);
        Task<IdentityResult> CreateUserAsync(User user, string password);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<IdentityResult> DeleteUserAsync(string id);
    }
}
