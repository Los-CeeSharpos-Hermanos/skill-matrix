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
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[1].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C#",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[1].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[3].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[8].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[2].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[4].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = UsersSeed.defaultUsers[7].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[0].Id,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[5].Id,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[6].Id,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = UsersSeed.defaultUsers[9].Id,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
