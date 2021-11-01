using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Users.Repositories
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeamsAsync();
        Task<Team> GetTeamAsync(long id);
        Task PostTeamAsync(Team team);
        Task PutTeamAsync(Team team);
        Task DeleteTeamAsync(long id);
    }
}
