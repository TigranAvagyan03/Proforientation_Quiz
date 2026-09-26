namespace Proforientation_Quiz.Domain.Models
{
    public class QuizAttempt
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int  UserAttemptNumber { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }

        
        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
        public QuizResult? Result { get; set; }
    }
}
