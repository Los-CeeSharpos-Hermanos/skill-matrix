using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
