using System.Collections.Generic;

namespace SkillMatrix.Domain.Users.Models
{
    public class User : BaseEntity
    {
        public long Id { get; set; }
        public string SurName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }

        public long? DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public long? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
