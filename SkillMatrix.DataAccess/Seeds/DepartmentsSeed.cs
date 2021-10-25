using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class DepartmentsSeed
    {
        public static void SeedDepartments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
               .HasData(
                   new Department { Id = 1, Name = "Sales" },
                   new Department { Id = 2, Name = "Development" }
            );
        }
    }
}
