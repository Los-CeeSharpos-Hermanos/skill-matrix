using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.DTOs
{
    public class DepartmentDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<string> Users { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
