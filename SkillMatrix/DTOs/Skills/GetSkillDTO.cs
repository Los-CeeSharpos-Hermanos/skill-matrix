using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillMatrix.Application.DTOs.Skills
{
    public class GetSkillDTO
    {
        public long Id { get; set; }
        public string SkillName { get; set; }
        public string SkillCategory { get; set; }
    }
}
