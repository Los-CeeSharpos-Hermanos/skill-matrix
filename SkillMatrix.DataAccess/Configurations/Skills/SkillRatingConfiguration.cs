using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Skills.Models;
using SkillMatrix.Domain.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrix.DataAccess.Configurations.Skills
{
    public class SkillRatingConfiguration : IEntityTypeConfiguration<SkillRating>
    {
        public void Configure(EntityTypeBuilder<SkillRating> builder)
        {
            builder.HasKey(sr => new { sr.UserId, sr.SkillId });
            builder.Property(x => x.Rating).HasConversion<int>();
        }
    }
}
