using SkillMatrix.Domain.Skills.Enums;


namespace SkillMatrix.Domain.Users.Models
{
    public class LanguageRating
    {
        public long LanguageRatingId { get; set; }
        public long LanguageId { get; set; }
        public long UserId { get; set; }
        public Rating Rating { get; set; }
    }
}
