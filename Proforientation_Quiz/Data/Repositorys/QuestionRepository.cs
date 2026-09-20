using Microsoft.EntityFrameworkCore;
using Proforientation_Quiz.Data.Repositorys.Interfaces;
using Proforientation_Quiz.Models;

namespace Proforientation_Quiz.Data.Repositorys
{
    public class QuestionRepository : IQuestionRepository
    {

        private readonly ApplicationDbContext _context;
        public QuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return  await _context.Questions.ToListAsync();
        }

        public async Task<Question?> GetFirstUnansweredAsync(int attemptId)
        {
            return await _context.Questions.Include(q => q.Options).Where(q => !_context.UserAnswers.Any(ua => ua.QuizAttemptId == attemptId && ua.QuestionId == q.Id)).OrderBy(q=>q.Id).FirstOrDefaultAsync();
        }

        public async Task<Question?> GetQuestionByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Question?> GetQuestionWithAnswersAsync(int id)
        {
            return await _context.Questions.Include(q=>q.Options).FirstOrDefaultAsync(q=>q.Id == id);
        }

        public async Task<int> GetTotalQuestionsCountAsync()
        {
           return await _context.Questions.CountAsync();
        }
    }
}
