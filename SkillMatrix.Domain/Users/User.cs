using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Users
{
    public class User
    {
        public long Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string email { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<Skill.Skill> Skills { get; set; }
        public virtual ICollection<Languages.Language> Languages { get; set; }
        //public virtual Department Department { get; set; }
        //public virtual Team Team { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
