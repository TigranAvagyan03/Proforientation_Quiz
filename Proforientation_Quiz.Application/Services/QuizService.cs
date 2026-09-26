using Proforientation_Quiz.Application.Interfaces;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Application.Services.Interfaces;

namespace Proforientation_Quiz.Application.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IQuizAttemptRepository _quizAttemptRepository;

        public QuizService(IUserAnswerRepository userAnswerRepository, IQuestionRepository questionRepository, IQuizAttemptRepository quizAttemptRepository)
        {
            _userAnswerRepository = userAnswerRepository;
            _questionRepository = questionRepository;
            _quizAttemptRepository = quizAttemptRepository;
        }

        public async Task CompleteAttemptAsync(int attemptId)
        {
            await _quizAttemptRepository.CompleteAttemptAsync(attemptId);
        }

        public async Task<QuizAttempt?> GetLastAttemptAsync(string userId)
        {
            return await _quizAttemptRepository.GetLastAttemptAsync(userId);
        }

        public async Task<Question?> GetNextQuestionAsync(int attemptId)
        {
            
            return await _questionRepository.GetFirstUnansweredAsync(attemptId);
           
        }

        public async Task<QuizAttempt> GetOrCreateActiveAttemptAsync(string userId)
        {
            var active = await _quizAttemptRepository.GetActiveAttemptAsync(userId);
            if (active != null)
                return active;
            var count = await _quizAttemptRepository.GetAttemptCountAsync(userId);
            var newAttempt = new QuizAttempt
            {
                UserId = userId,
                UserAttemptNumber = count + 1,
                StartedAt = DateTime.UtcNow
            };
            await _quizAttemptRepository.AddAsync(newAttempt);
            return newAttempt;
        }

        public async Task<bool> IsQuizCompletedAsync(int attemptId)
        {
            var answered = await _userAnswerRepository.GetCountByAttemptIdAsync(attemptId);
            var questionCount= await _questionRepository.GetTotalQuestionsCountAsync();

            return answered >= questionCount;
        }

        public async Task StartNewAttemptAsync(string userId)
        {
            var count = await _quizAttemptRepository.GetAttemptCountAsync(userId);
            var newAttempt = new QuizAttempt();
            newAttempt.UserId = userId;
            newAttempt.UserAttemptNumber = count + 1;
            newAttempt.StartedAt = DateTime.UtcNow;
            

            await _quizAttemptRepository.AddAsync(newAttempt);
        }

        public async Task SubmitAnswerAsync(string userId, int questionId, int answerId, int attemptId)
        {
            
            UserAnswer userAnswer = new UserAnswer();
            userAnswer.UserId = userId;
            userAnswer.QuestionId = questionId;
            userAnswer.AnswerOptionId = answerId;
            userAnswer.QuizAttemptId = attemptId;
            userAnswer.CreatedAt = DateTime.UtcNow;

            await _userAnswerRepository.AddAsync(userAnswer);
        }
    }
}
