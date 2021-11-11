using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Enums;
using SkillMatrix.Domain.Users.Models;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class LanguageRatingSeed
    {
        public static void SeedLanguageRatings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageRating>()
               .HasData(
                   new LanguageRating
                   {
                       LanguageRatingId = 1,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 2,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 3,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 4,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 5,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 6,
                       Language = "french",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 7,
                       Language = "latin",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Begginer
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 8,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 9,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 10,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 11,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 12,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 13,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 14,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 15,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 17,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 16,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 18,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 19,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 20,
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       LanguageRatingId = 21,
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
