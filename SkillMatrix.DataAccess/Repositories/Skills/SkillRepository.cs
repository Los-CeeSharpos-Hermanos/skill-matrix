using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Skills.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SkillMatrix.DataAccess.Repositories.Skills
{
    public class SkillRepository : ISkillRepository
    {
        private readonly ApplicationDBContext _db;

        public SkillRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return _db.Skills.AsNoTracking().Where(p => p.SkillId > 0);
        }
    }
}
