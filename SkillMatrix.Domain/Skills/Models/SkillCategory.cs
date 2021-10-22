using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Skills.Models
{
    public class SkillCategory : BaseEntity
    {
        public long SkillCategoryId { get; set; }
        public string SkillCategoryName { get; set; }
        public virtual IEnumerable<Skill> Skills { get; set; }
    }
}