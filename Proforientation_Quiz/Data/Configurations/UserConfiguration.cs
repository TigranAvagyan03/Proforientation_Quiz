using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u=>u.UserAnswers).WithOne(ua=>ua.User).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u=>u.QuizResults).WithOne(qr=>qr.User).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u=>u.QuizAttempts).WithOne(qa=>qa.User).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
