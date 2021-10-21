using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Models;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class SkillCategoriesSeed
    {
        public static void SeedSkillCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillCategory>()
                .HasData(
                   new SkillCategory { SkillCategoryId = 1, SkillCategoryName = "Technical Skills" },
                   new SkillCategory { SkillCategoryId = 2, SkillCategoryName = "Soft Skills" },
                   new SkillCategory { SkillCategoryId = 3, SkillCategoryName = "SWOValue" },
                   new SkillCategory { SkillCategoryId = 4, SkillCategoryName = "Sport" }
            );
        }
    }
}
