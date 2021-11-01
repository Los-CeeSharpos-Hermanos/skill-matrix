using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using SkillMatrix.Domain.Languages.Models;
using SkillMatrix.DataAccess.Seeds;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.DataAccess.Skills;
using SkillMatrix.Domain.Users.Models;
using SkillMatrix.DataAccess.Configurations;
using SkillMatrix.Domain.Teams;

namespace SkillMatrix.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "SkillMatrix",
                IntegratedSecurity = true
            };

            optionsBuilder
                .UseSqlServer(connectionStringBuilder.ConnectionString)
                .UseLazyLoadingProxies();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());

            modelBuilder.InsertSeeds();
        }

        public void UpdateDatabase()
        {
            Database.Migrate();
        }

    }
}
