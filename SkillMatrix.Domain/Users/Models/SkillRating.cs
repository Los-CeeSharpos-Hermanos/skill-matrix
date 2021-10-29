using SkillMatrix.Domain.Skills.Enums;


namespace SkillMatrix.Domain.Users.Models
{
    public class SkillRating
    {
        public long SkillRatingId { get; set; }
        public long SkillId { get; set; }
        public long UserId { get; set; }
        public Rating Rating { get; set; }
    }
}
