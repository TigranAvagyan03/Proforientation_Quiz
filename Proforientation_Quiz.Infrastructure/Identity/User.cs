using Microsoft.AspNetCore.Identity;
using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Infrastructure.Identity
{
    public class User: IdentityUser
    {
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();

        public ICollection<QuizResult> QuizResults { get; set; }= new List<QuizResult>();

        public ICollection<QuizAttempt> QuizAttempts { get; set; }=new List<QuizAttempt>();

        
    }
}
