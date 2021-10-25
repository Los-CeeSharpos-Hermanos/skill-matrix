using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class UsersSeed
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasData(
                   new User { Id = 1, FirstName = "Martin", SurName = "Schmidt", Email = "martin.schmidt@web.de"},
                   new User { Id = 2, FirstName = "Bernd", SurName = "Meier", Email = "bernd.meier@web.de" },
                   new User { Id = 3, FirstName = "Lutz", SurName = "Seehofer", Email = "lutz.seehofer@web.de" },
                   new User { Id = 4, FirstName = "Hans", SurName = "Zwei", Email = "hans.zwei@email.com" }
             );
        }
    }
}
