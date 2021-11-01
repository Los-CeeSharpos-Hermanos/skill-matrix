using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Users.Models
{
    public class Department : BaseEntity
    {
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
