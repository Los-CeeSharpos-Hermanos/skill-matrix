using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Skills.Models;

namespace SkillMatrix.DataAccess.Skills
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();
<<<<<<< HEAD:SkillMatrix.DataAccess/Configurations/SkillConfiguration.cs

            builder.HasOne(p => p.SkillCategory);
          

=======
>>>>>>> main:SkillMatrix.DataAccess/Configurations/Skills/SkillConfiguration.cs
        }
    }
}
