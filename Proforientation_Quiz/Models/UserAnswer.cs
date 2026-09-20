namespace Proforientation_Quiz.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public int QuestionId { get; set; }

        public int AnswerOptionId {  get; set; }

        public int QuizAttemptId {  get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;

        public Question Question { get; set; } = null!;

        public AnswerOption Option { get; set; } = null!;

        public QuizAttempt QuizAttempt { get; set; } = null!;
    }
}
