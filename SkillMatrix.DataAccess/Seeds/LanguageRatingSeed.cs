using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Enums;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class LanguageRatingSeed
    {
        public static void SeedLangugaeRatings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageRating>()
               .HasData(
                   new LanguageRating
                   {
                       LanguageRatingId = 1,
                       LanguageId = 40,
                       UserId = 1,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
