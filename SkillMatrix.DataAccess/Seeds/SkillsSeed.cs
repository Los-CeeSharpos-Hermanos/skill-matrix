using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Models;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class SkillsSeed
    {
        public static void SeedSkills(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
               .HasData(
                   new Skill { SkillId = 1, SkillName = "C#", SkillCategoryId = 1 },
                   new Skill { SkillId = 2, SkillName = "Java", SkillCategoryId = 1 },
                   new Skill { SkillId = 3, SkillName = "JavaScript", SkillCategoryId = 1 },
                   new Skill { SkillId = 4, SkillName = "Python", SkillCategoryId = 1 },
                   new Skill { SkillId = 5, SkillName = "Team Play", SkillCategoryId = 2 },
                   new Skill { SkillId = 6, SkillName = "Speed", SkillCategoryId = 3 },
                   new Skill { SkillId = 7, SkillName = "Soccer", SkillCategoryId = 4 }
            );
        }
    }
}
