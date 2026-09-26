using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Infrastructure.Data.Configurations
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.ToTable("Professions");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);

            builder.OwnsOne(p => p.Traits);

            builder.Property(p => p.RecommendationText).IsRequired().HasMaxLength(2000);

            builder.HasMany(p=>p.QuizResults).WithOne(qr=>qr.Profession).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
