using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Configurations.Skills
{
    class SkillCategoryConfiguration : IEntityTypeConfiguration<SkillCategory>
    {

        public void Configure(EntityTypeBuilder<SkillCategory> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();

            builder.HasMany(p => p.Skills).WithOne(p => p.SkillCategory);

        }
    }
}
