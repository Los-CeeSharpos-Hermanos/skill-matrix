using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SkillMatrix.Domain.Users.Models
{
    public class User : IdentityUser
    {
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Telephone { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }

        public string JobTitle { get; set; }
        public long? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public long? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<LanguageRating> LanguageRatings { get; set; } = new Collection<LanguageRating>();
        public virtual ICollection<SkillRating> SkillRatings { get; set; } = new Collection<SkillRating>();
    }
}
