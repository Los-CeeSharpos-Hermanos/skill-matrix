using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Teams;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class TeamsSeed
    {
        public static void SeedTeams(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
               .HasData(
                   new Team { TeamId = 1, TeamName = "A-Team" },
                   new Team { TeamId = 2, TeamName = "B-Team" }
            );
        }
    }
}
