using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Skills.Models
{
    public class Skill : BaseEntity
    {
        public long SkillId { get; set; }
        public string SkillName { get; set; }
        public long SkillCategoryId { get; set; }
        public virtual SkillCategory SkillCategory { get; set; }
        

    }
}
