using Microsoft.EntityFrameworkCore;
using Proforientation_Quiz.Data.Repositorys.Interfaces;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys
{
    public class UserAnswersRepository : IUserAnswerRepository
    {
       private  readonly ApplicationDbContext _context;
        public UserAnswersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(UserAnswer answer)
        {
          await _context.UserAnswers.AddAsync(answer);
          await  _context.SaveChangesAsync();
        }

        public async Task<List<UserAnswer>> GetAnswersByAttemptIdAsync(int attemptId)
        {
            return await _context.UserAnswers.Include(ua=>ua.Option).Where(ua=>ua.QuizAttemptId== attemptId).ToListAsync();
        }

       
        public async  Task<int> GetCountByAttemptIdAsync(int attemptId)
        {
            return await _context.UserAnswers.Where(ua => ua.QuizAttemptId==attemptId).CountAsync();
        }

       
    }
}
