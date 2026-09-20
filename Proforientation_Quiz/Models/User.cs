using Microsoft.AspNetCore.Identity;

namespace Proforientation_Quiz.Models
{
    public class User: IdentityUser
    {
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();

        public ICollection<QuizResult> QuizResults { get; set; }= new List<QuizResult>();

        public ICollection<QuizAttempt> QuizAttempts { get; set; }=new List<QuizAttempt>();

        
    }
}
