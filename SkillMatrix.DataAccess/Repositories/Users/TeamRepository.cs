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
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDBContext _db;

        public TeamRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Team>> GetTeamsAsync()
        {
            return await _db.Teams.Where(p => p.TeamId > 0)
                                  .OrderBy(t => t.TeamId)
                                  .ToListAsync();
        }

        public async Task<Team> GetTeamAsync(long id)
        {
            return await _db.Teams.FindAsync(id);
        }

        public async Task PostTeamAsync(Team team)
        {
            await _db.Teams.AddAsync(team);
            await _db.SaveChangesAsync();
        }

        public async Task PutTeamAsync(Team team)
        {
            _db.Teams.Update(team);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteTeamAsync(long id)
        {
            Team dbTeam = await _db.Teams.Where(team => team.TeamId == id).FirstOrDefaultAsync()
                ?? throw new KeyNotFoundException("$Team not found");
            _db.Teams.Remove(dbTeam);
            await _db.SaveChangesAsync();
        }
    }
}
