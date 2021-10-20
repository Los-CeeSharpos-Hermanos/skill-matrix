using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class SkillsSeed
    {
        public static void SeedSkills(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
               .HasData(
                   new Skill { SkillId = 1, Name = "C#", SkillCategoryId = 1 },
                   new Skill { SkillId = 2, Name = "Java", SkillCategoryId = 1 },
                   new Skill { SkillId = 3, Name = "JavaScript", SkillCategoryId = 1 },
                   new Skill { SkillId = 4, Name = "Python", SkillCategoryId = 1 },
                   new Skill { SkillId = 5, Name = "Team Play", SkillCategoryId = 2 },
                   new Skill { SkillId = 6, Name = "Speed", SkillCategoryId = 3 },
                   new Skill { SkillId = 7, Name = "Soccer", SkillCategoryId = 4 }
            );
        }
    }
}
