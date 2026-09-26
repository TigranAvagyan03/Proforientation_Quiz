using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Application.Interfaces
{
    public interface IQuizResultRepository
    {
        Task AddAsync(QuizResult result);
        Task<QuizResult?> GetByAttemptIdAsync(int attemptId);
    }
}
