using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys.Interfaces
{
    public interface IUserAnswerRepository
    {
        Task AddAsync(UserAnswer answer);

        Task<int> GetCountByAttemptIdAsync(int attemptId);

        Task<List<UserAnswer>> GetAnswersByAttemptIdAsync(int attemptId);
    }
}
