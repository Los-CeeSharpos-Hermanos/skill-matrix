using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class SkillCategoriesSeed
    {
        public static void SeedSkillCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillCategory>()
                .HasData(
                   new SkillCategory { SkillCategoryId = 1, Name = "Technical Skills" },
                   new SkillCategory { SkillCategoryId = 2, Name = "Soft Skills" },
                   new SkillCategory { SkillCategoryId = 3, Name = "SWOValue" },
                   new SkillCategory { SkillCategoryId = 4, Name = "Sport" }
            );
        }
    }
}
