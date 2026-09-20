using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Configurations
{
    public class UserAnswerConfiguration : IEntityTypeConfiguration<UserAnswer>
    {
        public void Configure(EntityTypeBuilder<UserAnswer> builder)
        {
            builder.ToTable("UserAnswers");

            builder.HasKey(ua => ua.Id);

            builder.Property(ua => ua.UserId).IsRequired();
            builder.Property(ua => ua.QuestionId).IsRequired();
            builder.Property(ua => ua.AnswerOptionId).IsRequired();
            builder.Property(ua=>ua.QuizAttemptId).IsRequired();
            builder.Property(ua => ua.CreatedAt).HasDefaultValueSql("NOW()");

            builder.HasOne(ua=>ua.User).WithMany(u=>u.UserAnswers).HasForeignKey(ua=>ua.UserId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua=>ua.Question).WithMany(q=>q.UserAnswers).HasForeignKey(ua=>ua.QuestionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua => ua.Option).WithMany(o => o.UserAnswers).HasForeignKey(ua => ua.AnswerOptionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ua=>ua.QuizAttempt).WithMany(qa=>qa.UserAnswers).HasForeignKey(ua=>ua.QuizAttemptId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
