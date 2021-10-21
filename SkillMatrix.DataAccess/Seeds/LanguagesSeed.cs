using Microsoft.EntityFrameworkCore;
using SkillMatrix.Domain.Languages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Seeds
{
    public static class LanguagesSeed
    {
        public static void SeedLanguages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>()
                .HasData(
                    new Language { Id = 1, Code = "en", Name = "English", NativeName = "English" },
                    new Language { Id = 2, Code = "de", Name = "German", NativeName = "Deutsch" }
                );
        }
    }
}
