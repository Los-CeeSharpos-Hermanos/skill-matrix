using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills;

using SkillMatrix.Domain.Languages;
using SkillMatrix.Domain.Users;
using SkillMatrix.DataAccess.Seeds;


namespace SkillMatrix.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }

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

            modelBuilder.InsertSeeds();
        }

        public void UpdateDatabase()        
        {
            Database.Migrate();
        }

    }
}
