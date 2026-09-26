using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Identity;

namespace Proforientation_Quiz.Infrastructure.Data.Configurations
{
    public class QuizAttemptConfiguration : IEntityTypeConfiguration<QuizAttempt>
    {
        public void Configure(EntityTypeBuilder<QuizAttempt> builder)
        {
            builder.ToTable("QuizAttempts");

            builder.HasKey(qa => qa.Id);

            builder.Property(qa=>qa.UserId).IsRequired();
            builder.Property(qa=>qa.UserAttemptNumber).IsRequired();

            builder.Property(qa=>qa.StartedAt).HasDefaultValueSql("NOW()");

            builder.HasOne<User>().WithMany(u => u.QuizAttempts).HasForeignKey(qa => qa.UserId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qa=>qa.Result).WithOne(qr=>qr.QuizAttempt).HasForeignKey<QuizResult>(qr=>qr.QuizAttemptId).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(qa=>qa.UserAnswers).WithOne(ua=>ua.QuizAttempt).HasForeignKey(ua=>ua.QuizAttemptId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
