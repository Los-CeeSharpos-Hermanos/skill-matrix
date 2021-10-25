using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.Domain.Skills.Models;
using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Users.Models
{
    public class User
    {
        public long Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Skill> Skills { get; set; }
        public virtual IEnumerable<Language> Languages { get; set; }

        public virtual Department Department { get; set; }
        public virtual Team Team { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
