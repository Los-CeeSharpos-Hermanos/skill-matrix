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
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "french",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "latin",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Begginer
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Advanced
                   },
                   new LanguageRating
                   {
                       Language = "english",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Intermediate
                   },
                   new LanguageRating
                   {
                       Language = "german",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
