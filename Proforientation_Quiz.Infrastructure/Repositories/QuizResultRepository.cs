using Microsoft.EntityFrameworkCore;
using Proforientation_Quiz.Application.Interfaces;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Data;

namespace Proforientation_Quiz.Infrastructure.Repositories
{
    public class QuizResultRepository : IQuizResultRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizResultRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(QuizResult result)
        {
           await _context.AddAsync(result);
           await _context.SaveChangesAsync();
        }

        public async Task<QuizResult?> GetByAttemptIdAsync(int attemptId)
        {
            return await _context.QuizResults.FirstOrDefaultAsync(qr => qr.QuizAttemptId == attemptId);
        }
    }
}
