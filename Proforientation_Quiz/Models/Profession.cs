namespace Proforientation_Quiz.Models
{
    public class Profession
    {
        public int Id { get; set; }

        public string Title { get; set; }=string.Empty;

        public string Description { get; set; } = string.Empty;

        public TraitsVector Traits { get; set; } = new();

        public string RecommendationText {  get; set; } = string.Empty;

        public ICollection<QuizResult> QuizResults { get; set; } = new List<QuizResult>();
    }
}
