using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.DTOs
{
    public class FormTeamDTO
    {
        public string TeammName { get; set; }
        public long DepartmentId { get; set; }
        public List<long> UserIds { get; set; }
    }
}
