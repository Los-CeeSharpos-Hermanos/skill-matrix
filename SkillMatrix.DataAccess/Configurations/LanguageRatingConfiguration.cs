using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillMatrix.Domain.Users.Models;

namespace SkillMatrix.DataAccess.Configurations
{
    public class LanguageRatingConfiguration : IEntityTypeConfiguration<LanguageRating>
    {
        public void Configure(EntityTypeBuilder<LanguageRating> builder)
        {
            builder.HasKey(u => new { u.Language, u.UserId });
        }
    }
}
