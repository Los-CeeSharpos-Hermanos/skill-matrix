using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Skills.Models;

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
