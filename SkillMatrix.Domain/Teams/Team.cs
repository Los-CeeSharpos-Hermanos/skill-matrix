using SkillMatrix.Domain.Users.Models;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Teams
{
    public class Team : BaseEntity
    {
        public long TeamId { get; set; }
        public string TeamName { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
