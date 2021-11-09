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
                       UserId = 1,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C#",
                       UserId = 2,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C#",
                       UserId = 3,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C#",
                       UserId = 4,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = 1,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = 3,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = 8,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = 9,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "Java",
                       UserId = 10,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 1,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 2,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 3,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 4,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 5,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 6,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 7,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 8,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 9,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "HTML",
                       UserId = 10,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = 2,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = 4,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = 5,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C++",
                       UserId = 7,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = 1,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = 3,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = 7,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillName = "C",
                       UserId = 10,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
