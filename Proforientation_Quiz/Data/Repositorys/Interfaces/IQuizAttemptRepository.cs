using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys.Interfaces
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
