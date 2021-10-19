using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.DataAccess
{
    public class ApplicationDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "(localdb)\\MSSQLLocalDB",
                InitialCatalog = "SkillMatrix",
                IntegratedSecurity = true
            };

            optionsBuilder.UseSqlServer(connectionStringBuilder.ConnectionString);
        }      
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
