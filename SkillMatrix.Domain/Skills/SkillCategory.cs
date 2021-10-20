using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Skills
{
    public class SkillCategory
    {
        public long SkillCategoryId { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Skill> Skills { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}