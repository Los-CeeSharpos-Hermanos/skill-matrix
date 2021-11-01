using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Languages.Models
{
    public class Language : BaseEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }

        
    }
}
