using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using System.Collections.Generic;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class UsersSeed
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasData(
                   new User
                   {
                       Id = 1,
                       FirstName = "Martin",
                       SurName = "Schmidt",
                       Email = "martin.schmidt@web.de",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       DepartmentId = 1,
                       TeamId = 1,


                   }, new User
                   {
                       Id = 2,
                       FirstName = "Nico",
                       SurName = "Marten",
                       Email = "nico.marten@web.de",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       DepartmentId = 1,
                       TeamId = 1,

                   }
             );
        }

    }
}

