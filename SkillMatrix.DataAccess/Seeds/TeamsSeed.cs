using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class TeamsSeed
    {
        public static void SeedTeams(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
               .HasData(
                   new Team { Id = 1, Name = "A-Team" },
                   new Team { Id = 2, Name = "B-Team" }
            );
        }
    }
}
