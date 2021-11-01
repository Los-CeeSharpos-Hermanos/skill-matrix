using SkillMatrix.Application.DTOs.Skills;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.DTOs
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public IList<SkillRatingSummaryDTO> Skills { get; set; }
        public IList<LanguageRating> Languages { get; set; }
    }
}
