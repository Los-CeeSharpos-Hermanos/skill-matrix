using SkillMatrix.Domain.Skills.Enums;

namespace SkillMatrix.Application.DTOs
{
    public class UserSkillDTO
    {
        public string SkillName { get; set; }
        public string SkillCategory { get; set; }
        public Rating rating { get; set; }
    }
}