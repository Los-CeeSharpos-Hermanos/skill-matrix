using SkillMatrix.Domain.Skills.Enums;
using System;

namespace SkillMatrix.Domain.Users.Models
{
    public class SkillRating
    {
        public string SkillName { get; set; }
        public string UserId { get; set; }
        public Rating Rating { get; set; }
    }
}
