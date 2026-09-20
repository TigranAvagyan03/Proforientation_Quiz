using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys.Interfaces
{
    public interface IProfessionRepository
    {
        Task<Profession?> GetByIdAsync(int id);

        Task<List<Profession>> GetAllAsync();

    }
}
