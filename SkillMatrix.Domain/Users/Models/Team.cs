using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Users.Models
{
    public class Team : BaseEntity
    {
        public long TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
