using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Users.Models
{
    public class Team : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<User> Users { get; set; }
        public virtual Department Department { get; set; }
    }
}
