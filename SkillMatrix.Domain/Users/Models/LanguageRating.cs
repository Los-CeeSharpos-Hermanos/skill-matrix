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
        public LanguageRating Language { get; set; }
        public int RatingId { get; set; }
        public Rating Rating { get; set; }

    }
}
