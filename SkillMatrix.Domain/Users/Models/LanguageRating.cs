using SkillMatrix.Domain.Skills.Enums;

namespace SkillMatrix.Domain.Users.Models
{
    public class LanguageRating
    {
        public string Language { get; set; }
        public string UserId { get; set; }
        public Rating Rating { get; set; }
    }
}
