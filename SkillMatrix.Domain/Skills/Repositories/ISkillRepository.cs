using SkillMatrix.Domain.Skills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Skills.Repositories
{
    public interface ISkillRepository
    {
        Task<List<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSkillByIdAsync(long id);
        Task<int> AddSkillAsync(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(Skill skill);
    }
}
