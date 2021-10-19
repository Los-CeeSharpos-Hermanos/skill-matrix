using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Languages
{
    public class Language
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }

        public virtual ICollection<Users.User> Users { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
