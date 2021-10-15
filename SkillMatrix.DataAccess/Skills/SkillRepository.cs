using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkillMatrix.Domain.Skill;
using SkillMatrix.Domain.Skill.Repository;

namespace SkillMatrix.DataAccess.Skills
{
    public class SkillRepository : ISkillRepository
    {
        public List<Skill> GetSkillsWithPersonalData(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
