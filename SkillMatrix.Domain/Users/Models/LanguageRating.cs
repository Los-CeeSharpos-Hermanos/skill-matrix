using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Skills.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
