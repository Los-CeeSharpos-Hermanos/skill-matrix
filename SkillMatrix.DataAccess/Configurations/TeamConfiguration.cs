using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
<<<<<<< HEAD
using SkillMatrix.Domain.Users.Models;
=======
using SkillMatrix.Domain.Users;
>>>>>>> main

namespace SkillMatrix.DataAccess.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();

            builder.HasMany(p => p.Users);
            builder.HasOne(p => p.Department);
        }
    }
}
