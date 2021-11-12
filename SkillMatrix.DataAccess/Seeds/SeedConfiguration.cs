using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class SeedConfiguration
    {
        public static void InsertSeeds(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedSkillCategories();
            modelBuilder.SeedSkills();
            modelBuilder.SeedLanguages();
            modelBuilder.SeedDepartments();
            modelBuilder.SeedTeams();
            modelBuilder.SeedUsers();
            modelBuilder.SeedLanguageRatings();
            modelBuilder.SeedSkillRatings();
        }
    }
}
