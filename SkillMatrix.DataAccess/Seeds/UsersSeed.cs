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
                       Id = "1",
                       FirstName = "Martin",
                       SurName = "Schmidt",
                       Telephone = "0845679123",
                       Email = "martin.schmidt@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 1,
                   }, new User
                   {
                       Id = "2",
                       FirstName = "Nico",
                       SurName = "Marten",
                       Telephone = "0987654321",
                       Email = "nico.marten@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Software Architect",
                       DepartmentId = 1,
                       TeamId = 1,
                   }, new User
                   {
                       Id = "3",
                       FirstName = "Tom",
                       SurName = "Tompson",
                       Telephone = "0123456789",
                       Email = "tom.tompson@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Sailsman",
                       DepartmentId = 1,
                       TeamId = 2,
                   }, new User
                   {
                       Id = 4,
                       FirstName = "Nancy",
                       SurName = "Mustermann",
                       Telephone = "0125896743",
                       Email = "n.mustermann@web.de",
                       Location = "Dresden",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 2,
                   }, new User
                   {
                       Id = 5,
                       FirstName = "Mandy",
                       SurName = "Meyer",
                       Telephone = "0128764539",
                       Email = "mandy.meyer@gmail.com",
                       Location = "Munich",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 1,
                   }, new User
                   {
                       Id = 6,
                       FirstName = "Max",
                       SurName = "Mustermann",
                       Telephone = "017463589",
                       Email = "m.mustermann@gmx.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Sailsman",
                       DepartmentId = 2,
                       TeamId = 3,
                   }, new User
                   {
                       Id = 7,
                       FirstName = "C Montgomery",
                       SurName = "Burns",
                       Telephone = "0125634789",
                       Email = "c.burns@web.de",
                       Location = "Dresden",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "CEO",
                       DepartmentId = 2,
                       TeamId = 3,
                   }, new User
                   {
                       Id = 8,
                       FirstName = "Tim",
                       SurName = "Ford",
                       Telephone = "0123548697",
                       Email = "tim.ford@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 3,
                   }, new User
                   {
                       Id = 9,
                       FirstName = "Susi",
                       SurName = "Muller",
                       Telephone = "0321456789",
                       Email = "s.muller@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Marketing Expert",
                       DepartmentId = 3,
                       TeamId = 3,
                   }, new User
                   {
                       Id = 10,
                       FirstName = "Mary",
                       SurName = "Meier",
                       Telephone = "0213456789",
                       Email = "m.meier@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Marketing Expert",
                       DepartmentId = 3,
                       TeamId = 3,
                   }
             );
        }

    }
}

