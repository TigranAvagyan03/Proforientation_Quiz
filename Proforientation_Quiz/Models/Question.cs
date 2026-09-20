namespace Proforientation_Quiz.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Text {  get; set; }=string.Empty;

        public ICollection<AnswerOption> Options { get; set; } = new List<AnswerOption>();

        public ICollection<UserAnswer> UserAnswers { get; set; } = new List<UserAnswer>();
    }
}
