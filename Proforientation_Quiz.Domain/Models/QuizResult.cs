namespace Proforientation_Quiz.Domain.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public int ProfessionId {  get; set; }

        public int QuizAttemptId {  get; set; }

        public DateTime CreatedAt { get; set; }

       
        public Profession Profession { get; set; } = null!;

        public QuizAttempt QuizAttempt { get; set; }=null!;

        

    }
}
