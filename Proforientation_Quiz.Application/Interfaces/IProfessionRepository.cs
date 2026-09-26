using Proforientation_Quiz.Domain.Models;

namespace Proforientation_Quiz.Application.Interfaces
{
    public interface IProfessionRepository
    {
        Task<Profession?> GetByIdAsync(int id);

        Task<List<Profession>> GetAllAsync();

    }
}
