using System;

namespace SkillMatrix.Domain.Skill
{
    public class SkillCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}