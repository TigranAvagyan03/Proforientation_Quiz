using Microsoft.EntityFrameworkCore;
using Proforientation_Quiz.Data.Repositorys.Interfaces;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys
{
    public class QuizAttemptRepository : IQuizAttemptRepository
    {
        private readonly ApplicationDbContext _context;

        public QuizAttemptRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(QuizAttempt quizAttempt)
        {
           await _context.AddAsync(quizAttempt);
           await _context.SaveChangesAsync();
        }

        public async Task CompleteAttemptAsync(int attemptId)
        {
            var attempt= await _context.QuizAttempts.FindAsync(attemptId);
            if (attempt == null) return;

            if (attempt.CompletedAt == null)
            {
                attempt.CompletedAt = DateTime.UtcNow;
            }

            await _context.SaveChangesAsync();
            
        }

        public async Task<QuizAttempt?> GetActiveAttemptAsync(string userId)
        {
            return await _context.QuizAttempts.FirstOrDefaultAsync(qa => qa.UserId == userId && qa.CompletedAt == null);
        }

        public Task<int> GetAttemptCountAsync(string userId)
        {
            return _context.QuizAttempts.CountAsync(qa => qa.UserId == userId);
        }

        public async Task<QuizAttempt?> GetLastAttemptAsync(string userId)
        {
            return await _context.QuizAttempts.Where(qa=>qa.UserId == userId).OrderByDescending(qa=>qa.StartedAt).FirstOrDefaultAsync();
        }
    }
}
