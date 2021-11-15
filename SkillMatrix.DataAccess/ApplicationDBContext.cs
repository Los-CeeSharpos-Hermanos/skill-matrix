using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.DataAccess.Seeds;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.DataAccess.Skills;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.DataAccess.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SkillMatrix.DataAccess.Infrastructures;

namespace SkillMatrix.DataAccess
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        private readonly IOptions<ConnectionStrings> _connectionString;

        public ApplicationDBContext(IOptions<ConnectionStrings> connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Language> Languages { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<LanguageRating> LanguageRatings { get; set; }
        public DbSet<SkillRating> SkillRatings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString.Value.SkillMatrixDb)
                .UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageRatingConfiguration());
            modelBuilder.ApplyConfiguration(new SkillRatingConfiguration());

            modelBuilder.InsertSeeds();
        }

        public void UpdateDatabase()
        {
            Database.Migrate();
        }

    }
}
