using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Teams;
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
        private readonly ApplicationDBContext _db;

        public UserRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _db.Users.Where(p => p.Id > 0)
                                  .OrderBy(u => u.SurName)
                                  .ToListAsync();
        }

        public async Task<User> GetUserAsync(long id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task PostUserAsync(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }
        public async Task PutUserAsync(long id, User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(long id)
        {
            User dbUser = await _db.Users.Where(user => user.Id == id).FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException($"User not found");

            _db.Users.Remove(dbUser);

            await _db.SaveChangesAsync();
        }

        public async Task<Department>GetDepartmentAsync(string department)
        {
            return await _db.Departments.Where(d => d.DepartmentName == department).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Department not found");
        }

        public async Task<Team> GetTeamAsync(string team)
        {
            return await _db.Teams.Where(d => d.TeamName == team).FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Team not found");
        }
    }
}
