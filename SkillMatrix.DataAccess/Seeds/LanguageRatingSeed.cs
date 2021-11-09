using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Enums;
using SkillMatrix.Domain.Users.Models;

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
                       Language = "german",
                       UserId = 1,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 2,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 2,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 3,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 3,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "french",
                       UserId = 3,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "latin",
                       UserId = 3,
                       Rating = Rating.Begginer
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 4,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 4,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 5,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 5,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 6,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 6,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 7,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 7,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 8,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 8,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 9,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 9,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = 10,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = 10,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
