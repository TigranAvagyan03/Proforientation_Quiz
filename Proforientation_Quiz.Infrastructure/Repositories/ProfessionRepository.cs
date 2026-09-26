using Microsoft.EntityFrameworkCore;
using Proforientation_Quiz.Application.Interfaces;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Data;

namespace Proforientation_Quiz.Infrastructure.Repositories
{
    public class ProfessionRepository : IProfessionRepository
    {

        private readonly ApplicationDbContext _context;
        public ProfessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Profession?> GetByIdAsync(int id)
        {
           return await _context.Professions.FindAsync(id);
        }

       public async  Task<List<Profession>> GetAllAsync()
        {
           return await _context.Professions.ToListAsync();
        }
    }
}
