using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Enums;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class SkillRatingSeed
    {
        public static void SeedSkillRatings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillRating>()
               .HasData(
                   new SkillRating
                   {
                       SkillRatingId = 1,
                       SkillName = "C#",
                       UserId = 1,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
