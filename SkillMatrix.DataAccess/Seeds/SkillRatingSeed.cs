using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Skills.Enums;
using SkillMatrix.Domain.Users.Models;

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
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 2,
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[1].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 3,
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 4,
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 5,
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 6,
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 7,
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 8,
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 9,
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 10,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 11,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[1].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 12,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 13,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 14,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 15,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 16,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 17,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 18,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 19,
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 20,
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 21,
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 22,
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 23,
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 24,
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 25,
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 26,
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 27,
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
