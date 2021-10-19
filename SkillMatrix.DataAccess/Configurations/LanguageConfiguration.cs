using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();

            builder.HasMany(p => p.Users);
        }
    }
}
