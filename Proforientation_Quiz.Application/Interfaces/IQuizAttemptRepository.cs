using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Application.Interfaces
{
    public interface IQuizAttemptRepository
    {
        Task AddAsync(QuizAttempt quizAttempt);

        Task<QuizAttempt?> GetActiveAttemptAsync(string userId);

        Task<int> GetAttemptCountAsync(string userId);

        Task CompleteAttemptAsync(int attemptId);
        Task<QuizAttempt?> GetLastAttemptAsync(string userId);

    }
}
