namespace Proforientation_Quiz.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public int ProfessionId {  get; set; }

        public int QuizAttemptId {  get; set; }

        public DateTime CreatedAt { get; set; }

        public User User { get; set; } = null!;

        public Profession Profession { get; set; } = null!;

        public QuizAttempt QuizAttempt { get; set; }=null!;

        

    }
}
