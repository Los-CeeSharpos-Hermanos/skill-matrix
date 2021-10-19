﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skill;
using SkillMatrix.Domain.Languages;

namespace SkillMatrix.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillCategory> SkillCategories { get; set; }
        public DbSet<Language> Languages { get; set; }

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
        }

    }
}
