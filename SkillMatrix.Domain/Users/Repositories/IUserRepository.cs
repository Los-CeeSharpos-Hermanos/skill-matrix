using SkillMatrix.Domain.Teams;
using SkillMatrix.Domain.Users.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Users.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> ListUsersAsync();
        Task<User> GetUserAsync(long id);
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(long id, User user);
        Task DeleteUserAsync(long id);
        Task<Department> GetDepartmentAsync(string department);
        Task<Team> GetTeamAsync(string team);
    }
}
