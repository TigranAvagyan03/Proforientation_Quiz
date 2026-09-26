using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Application.Interfaces
{
    public interface IQuestionRepository
    {
        Task<Question?> GetQuestionWithAnswersAsync(int id);
        Task<int> GetTotalQuestionsCountAsync();

        Task<List<Question>> GetAllQuestionsAsync();

        Task<Question?> GetFirstUnansweredAsync(int attemptId);

        Task<Question?> GetQuestionByIdAsync(int id);

    }
}
