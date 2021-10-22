using SkillMatrix.Domain.Users;
using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Languages.Models
{
    public class Language
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }

        public virtual IEnumerable<User> Users { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
