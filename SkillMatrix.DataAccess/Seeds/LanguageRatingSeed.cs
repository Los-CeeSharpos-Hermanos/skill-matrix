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
    public static class LanguageRatingSeed
    {
        public static void SeedLangugaeRatings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageRating>()
               .HasData(
                   new LanguageRating
                   {
                       LanguageRatingId = 1,
                       Language = "german",
                       UserId = 1,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 2,
                       Language = "english",
                       UserId = 2,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 3,
                       Language = "german",
                       UserId = 2,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 4,
                       Language = "german",
                       UserId = 3,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 5,
                       Language = "english",
                       UserId = 3,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 6,
                       Language = "french",
                       UserId = 3,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 7,
                       Language = "latin",
                       UserId = 3,
                       Rating = Rating.Begginer
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 8,
                       Language = "english",
                       UserId = 4,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 9,
                       Language = "german",
                       UserId = 4,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 10,
                       Language = "english",
                       UserId = 5,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 11,
                       Language = "german",
                       UserId = 5,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 12,
                       Language = "english",
                       UserId = 6,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 13,
                       Language = "german",
                       UserId = 6,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 14,
                       Language = "english",
                       UserId = 7,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 15,
                       Language = "german",
                       UserId = 7,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 17,
                       Language = "english",
                       UserId = 8,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 16,
                       Language = "german",
                       UserId = 8,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 18,
                       Language = "english",
                       UserId = 9,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 19,
                       Language = "german",
                       UserId = 9,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 20,
                       Language = "english",
                       UserId = 10,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 21,
                       Language = "german",
                       UserId = 10,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
