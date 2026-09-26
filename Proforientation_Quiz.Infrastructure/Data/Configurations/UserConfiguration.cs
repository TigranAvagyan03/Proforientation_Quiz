using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Identity;

namespace Proforientation_Quiz.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u=>u.UserAnswers).WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u=>u.QuizResults).WithOne().OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u=>u.QuizAttempts).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
