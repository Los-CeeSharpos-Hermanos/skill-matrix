using SkillMatrix.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Skills
{
    public class Skill
    {
        public long SkillId { get; set; }
        public string Name { get; set; }
        public long SkillCategoryId { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
