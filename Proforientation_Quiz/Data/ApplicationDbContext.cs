using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

       public  DbSet<Question> Questions {  get; set; }
       
       public DbSet<AnswerOption> AnswerOptions { get; set; }
       
       public DbSet<Profession> Professions { get; set; }

       public DbSet<UserAnswer> UserAnswers { get; set; }

       public  DbSet<QuizResult> QuizResults { get; set; }
       
       public DbSet<QuizAttempt> QuizAttempts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
