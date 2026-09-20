using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Services.Interfaces
{
    public interface IProfessionService
    {
        Task<Profession?> GetUserProfessionAsync(int attemptId);
        Task SaveQuizResultAsync(string userId, int professionId, int attemptId);
    }
}
