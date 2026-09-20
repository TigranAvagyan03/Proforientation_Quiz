using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys.Interfaces
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
