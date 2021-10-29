using System.Collections.Generic;

namespace SkillMatrix.Application.DTOs
{
    public class TeamDTO
    {
        public long TeamId { get; set; }
        public string TeamName { get; set; }

        public List<string> UsersIds { get; set; }
        public List<string> UsersSurnames { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentId { get; set; }
    }
}
