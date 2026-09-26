using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Application.Services.Interfaces
{
    public interface IProfessionService
    {
        Task<Profession?> GetUserProfessionAsync(int attemptId);
        Task SaveQuizResultAsync(string userId, int professionId, int attemptId);
    }
}
