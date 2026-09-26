using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Infrastructure.Data.Configurations
{
    public class AnswerOptionConfiguration : IEntityTypeConfiguration<AnswerOption>
    {
        public void Configure(EntityTypeBuilder<AnswerOption> builder)
        {

            builder.ToTable("AnswerOptions");

            builder.HasKey(o => o.Id);

            builder.Property(o=>o.Text).IsRequired().HasMaxLength(500);

            builder.OwnsOne(o => o.Traits);

            builder.HasOne(o => o.Question).WithMany(q => q.Options).HasForeignKey(o => o.QuestionId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.UserAnswers).WithOne(a => a.Option).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
