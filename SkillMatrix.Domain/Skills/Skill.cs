using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.Domain.Skill
{
    public class Skill
    {
        private Skill(string name, string category)
        {
            Name = name;
            Category = category;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }

        public static Skill Create(string name, string category)
        {
            return new Skill(name, category);
        }

    }
}
