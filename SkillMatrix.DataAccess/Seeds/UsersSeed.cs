using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class UsersSeed
    {
        public static readonly List<User> defaultUsers = new List<User>
           {
                new User
                   {
                       Id = "2647ef6e-3a78-4f27-8cd0-7e9478e9e8ef",
                       FirstName = "Martin",
                       SurName = "Schmidt",
                       Telephone = "0845679123",
                       Email = "martin.schmidt@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 1,
                   },
                new User
                   {
                       Id = "96fa3c64-5640-4ee9-a37a-bdacb8c43005",
                       FirstName = "Nico",
                       SurName = "Marten",
                       Telephone = "0987654321",
                       Email = "nico.marten@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Software Architect",
                       DepartmentId = 1,
                       TeamId = 1,
                   },
                new User
                   {
                       Id = "e78986c7-9c10-4c87-b639-ba38fc64e10b",
                       FirstName = "Tom",
                       SurName = "Tompson",
                       Telephone = "0123456789",
                       Email = "tom.tompson@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Sailsman",
                       DepartmentId = 1,
                       TeamId = 2,
                   },
                new User
                   {
                       Id = "eb691e66-7037-4827-bf92-561f978acea7",
                       FirstName = "Nancy",
                       SurName = "Mustermann",
                       Telephone = "0125896743",
                       Email = "n.mustermann@web.de",
                       Location = "Dresden",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 2,
                   },
                new User
                   {
                       Id = "d26fba96-da21-43ac-8250-6b42374cc529",
                       FirstName = "Mandy",
                       SurName = "Meyer",
                       Telephone = "0128764539",
                       Email = "mandy.meyer@gmail.com",
                       Location = "Munich",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 1,
                   },
                new User
                   {
                       Id = "03902199-fb13-4f7d-b4d7-138bc849977f",
                       FirstName = "Max",
                       SurName = "Mustermann",
                       Telephone = "017463589",
                       Email = "m.mustermann@gmx.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Sailsman",
                       DepartmentId = 2,
                       TeamId = 3,
                   },
                new User
                   {
                       Id = "90db1068-f144-4d86-9851-7473ff53d6e4",
                       FirstName = "C Montgomery",
                       SurName = "Burns",
                       Telephone = "0125634789",
                       Email = "c.burns@web.de",
                       Location = "Dresden",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "CEO",
                       DepartmentId = 2,
                       TeamId = 3,
                   },
                new User
                   {
                       Id = "9f39b3a5-9e09-465d-a63d-34c1eac909c4",
                       FirstName = "Tim",
                       SurName = "Ford",
                       Telephone = "0123548697",
                       Email = "tim.ford@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Developer",
                       DepartmentId = 2,
                       TeamId = 3,
                   },
                new User
                   {
                       Id = "5a248924-7e9a-4de5-ad8b-86fc25163458",
                       FirstName = "Susi",
                       SurName = "Muller",
                       Telephone = "0321456789",
                       Email = "s.muller@web.de",
                       Location = "Leipzig",
                       ImageUrl = "https://w7.pngwing.com/pngs/340/946/png-transparent-avatar-user-computer-icons-software-developer-avatar-child-face-heroes-thumbnail.png",
                       JobTitle = "Marketing Expert",
                       DepartmentId = 3,
                       TeamId = 3,
                   },
                new User
                   {
                       Id = "85947f68-31e2-441c-983d-5b8df633835f",
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
            };

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasData(defaultUsers);
        }
    }
}

