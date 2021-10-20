using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Skill
{
    public class Skill
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
