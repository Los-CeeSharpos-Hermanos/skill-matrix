using SkillMatrix.Domain.Skills.Enums;


namespace SkillMatrix.Domain.Users.Models
{
    public class LanguageRating
    {
        public long LanguageRatingId { get; set; }
        public string LanguageName { get; set; }
        public long UserId { get; set; }
        public Rating Rating { get; set; }
    }
}
