using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Application.Interfaces
{
    public interface IUserAnswerRepository
    {
        Task AddAsync(UserAnswer answer);

        Task<int> GetCountByAttemptIdAsync(int attemptId);

        Task<List<UserAnswer>> GetAnswersByAttemptIdAsync(int attemptId);
    }
}
