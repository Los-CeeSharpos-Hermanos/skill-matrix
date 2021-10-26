using System.Collections.Generic;

namespace SkillMatrix.Application.DTOs
{
    public class TeamDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<string> UsersIds { get; set; }
        public List<string> UsersSurnames { get; set; }

        public string DepartmentName { get; set; }
        public string DepartmentId { get; set; }
    }
}
