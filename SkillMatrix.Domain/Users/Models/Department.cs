using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Users.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
