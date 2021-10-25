using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
<<<<<<< HEAD
using SkillMatrix.Domain.Users.Models;
=======
using SkillMatrix.Domain.Users;
>>>>>>> main

namespace SkillMatrix.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(p => p.UpdatedAt).HasDefaultValueSql("GETDATE()").ValueGeneratedOnUpdate();

            builder.HasMany(p => p.Skills).WithMany(s => s.Users);
            builder.HasMany(p => p.Languages);
            builder.HasOne(p => p.Department);
            builder.HasOne(p => p.Team);
        }
    }
}
