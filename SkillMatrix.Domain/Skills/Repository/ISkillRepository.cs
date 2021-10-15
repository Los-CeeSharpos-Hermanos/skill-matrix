using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Skill.Repository
{
    public interface ISkillRepository
    {
        List<Skill> GetSkillsWithPersonalData(int UserId);
    }
}
