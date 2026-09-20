using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Services.Interfaces
{
    public interface IQuizService
    {

        Task<Question?> GetNextQuestionAsync(int attemptId);
        Task SubmitAnswerAsync(string userId, int  questionId, int answerId, int attemptId);

        Task<bool> IsQuizCompletedAsync(int attemptId);

        Task StartNewAttemptAsync(string userId);
        Task<QuizAttempt> GetOrCreateActiveAttemptAsync(string userId);
        Task CompleteAttemptAsync(int attemptId);
        Task<QuizAttempt?> GetLastAttemptAsync(string userId);
    }
}
