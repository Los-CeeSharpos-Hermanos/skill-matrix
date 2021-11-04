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
                   }, new SkillRating
                   {
                       SkillRatingId = 2,
                       SkillName = "C#",
                       UserId = 2,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 3,
                       SkillName = "C#",
                       UserId = 3,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 4,
                       SkillName = "C#",
                       UserId = 4,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 5,
                       SkillName = "Java",
                       UserId = 1,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 6,
                       SkillName = "Java",
                       UserId = 3,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 7,
                       SkillName = "Java",
                       UserId = 8,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 8,
                       SkillName = "Java",
                       UserId = 9,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 9,
                       SkillName = "Java",
                       UserId = 10,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 10,
                       SkillName = "HTML",
                       UserId = 1,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 11,
                       SkillName = "HTML",
                       UserId = 2,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 12,
                       SkillName = "HTML",
                       UserId = 3,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 13,
                       SkillName = "HTML",
                       UserId = 4,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 14,
                       SkillName = "HTML",
                       UserId = 5,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 15,
                       SkillName = "HTML",
                       UserId = 6,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 16,
                       SkillName = "HTML",
                       UserId = 7,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 17,
                       SkillName = "HTML",
                       UserId = 8,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 18,
                       SkillName = "HTML",
                       UserId = 9,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 19,
                       SkillName = "HTML",
                       UserId = 10,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 20,
                       SkillName = "C++",
                       UserId = 2,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 21,
                       SkillName = "C++",
                       UserId = 4,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 22,
                       SkillName = "C++",
                       UserId = 5,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 23,
                       SkillName = "C++",
                       UserId = 7,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 24,
                       SkillName = "C",
                       UserId = 1,
                       Rating = Rating.Begginer
                   }, new SkillRating
                   {
                       SkillRatingId = 25,
                       SkillName = "C",
                       UserId = 3,
                       Rating = Rating.Advanced
                   }, new SkillRating
                   {
                       SkillRatingId = 26,
                       SkillName = "C",
                       UserId = 7,
                       Rating = Rating.Intermediate
                   }, new SkillRating
                   {
                       SkillRatingId = 27,
                       SkillName = "C",
                       UserId = 10,
                       Rating = Rating.Advanced
                   }
             );
        }
    }
}
