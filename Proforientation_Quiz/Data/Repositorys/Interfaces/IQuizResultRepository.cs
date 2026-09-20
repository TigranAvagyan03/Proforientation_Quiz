using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys.Interfaces
{
    public interface IQuizResultRepository
    {
        Task AddAsync(QuizResult result);
        Task<QuizResult?> GetByAttemptIdAsync(int attemptId);
    }
}
