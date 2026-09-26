using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Infrastructure.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("Questions");

            builder.HasKey(q => q.Id);

            builder.Property(q=>q.Text).IsRequired().HasMaxLength(500);

            builder.HasMany(q => q.Options).WithOne(o => o.Question).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q=>q.UserAnswers).WithOne(ua => ua.Question).OnDelete(DeleteBehavior.Restrict);


        }
    }
}
