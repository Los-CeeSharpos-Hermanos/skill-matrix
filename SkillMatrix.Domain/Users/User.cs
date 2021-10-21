using SkillMatrix.Domain.Languages;
<<<<<<< HEAD

=======
using SkillMatrix.Domain.Skills.Models;
>>>>>>> main
using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Users
{
    public class User
    {
        public long Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

<<<<<<< HEAD
        public virtual ICollection<Skill.Skill> Skills { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
=======
        public virtual ICollection<Skill> Skills { get; set; }
        public virtual ICollection<Language> Languages { get; set; }

>>>>>>> main
        public virtual Department Department { get; set; }
        public virtual Team Team { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
