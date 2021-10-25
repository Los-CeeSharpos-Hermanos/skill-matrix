<<<<<<< HEAD:SkillMatrix.Domain/Languages/Models/Language.cs
﻿using SkillMatrix.Domain.Users.Models;
=======
﻿using SkillMatrix.Domain.Users;
>>>>>>> main:SkillMatrix.Domain/Languages/Language.cs
using System;
using System.Collections.Generic;

namespace SkillMatrix.Domain.Languages.Models
{
    public class Language
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }

        public virtual IEnumerable<User> Users { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
