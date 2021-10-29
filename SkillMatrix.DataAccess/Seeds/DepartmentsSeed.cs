using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class DepartmentsSeed
    {
        public static void SeedDepartments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
               .HasData(
                   new Department { DepartmentId = 1, DepartmentName = "Sales" },
                   new Department { DepartmentId = 2, DepartmentName = "Development" },
                   new Department { DepartmentId = 3, DepartmentName = "Marketing" }
            );
        }
    }
}
