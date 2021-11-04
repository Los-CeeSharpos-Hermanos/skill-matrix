using SkillMatrix.Domain.Enums;
using SkillMatrix.Domain.Skills.Models;

namespace SkillMatrix.Domain.Users.Models
{
    public class SkillRating
    {

        public long SkillId { get; set; }
        public virtual Skill Skill { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public Rating Rating { get; set; }
    }
}
