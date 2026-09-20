using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Configurations
{
    public class QuizResultConfiguration : IEntityTypeConfiguration<QuizResult>
    {
        public void Configure(EntityTypeBuilder<QuizResult> builder)
        {
            builder.ToTable("QuizResults");

            builder.HasKey(qr => qr.Id);

            builder.Property(qr=>qr.UserId).IsRequired();
            builder.Property(qr=>qr.ProfessionId).IsRequired();
            builder.Property(qr=>qr.QuizAttemptId).IsRequired();

            builder.Property(qr=>qr.CreatedAt).HasDefaultValueSql("NOW()");

            builder.HasOne(qr=>qr.User).WithMany(u=>u.QuizResults).HasForeignKey(qr=>qr.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(qr=>qr.Profession).WithMany(p=>p.QuizResults).HasForeignKey(qr=>qr.ProfessionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(qr => qr.QuizAttempt).WithOne(qa => qa.Result).HasForeignKey<QuizResult>(qr => qr.QuizAttemptId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
