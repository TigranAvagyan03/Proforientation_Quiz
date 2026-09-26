using Proforientation_Quiz.Application.Interfaces;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Application.Services.Interfaces;

namespace Proforientation_Quiz.Application.Services
{
    public class ProfessionService : IProfessionService
    {
        private readonly IUserAnswerRepository _userAnswerRepository;
        private readonly IProfessionRepository _professionRepository;
        private readonly IQuizResultRepository _quizResultRepository;

        public ProfessionService(IUserAnswerRepository userAnswerRepository, IProfessionRepository professionRepository,IQuizResultRepository quizResultRepository)
        {
            _userAnswerRepository = userAnswerRepository;
            _professionRepository = professionRepository;
            _quizResultRepository= quizResultRepository;
        }

        public async Task<Profession?> GetUserProfessionAsync(int attemptId)
        {
            var answers= await _userAnswerRepository.GetAnswersByAttemptIdAsync(attemptId);

            if(!answers.Any()) return null;

            TraitsVector userTraits = TraitsVector.TraitsAverage(answers.Select(ua => ua.Option.Traits));

            var professions = await _professionRepository.GetAllAsync();

            if(!professions.Any()) return null;

            Profession? best = null;
            double minDistance=double.MaxValue;

            foreach (var profession in professions) 
            { 
                double distance=userTraits.ManhattanDistance(profession.Traits);

                if (distance < minDistance) 
                { 
                    minDistance=distance;
                    best = profession;
                }
            }
            return best;

        }

        public async Task SaveQuizResultAsync(string userId, int professionId, int attemptId)
        {
            var existing = await _quizResultRepository.GetByAttemptIdAsync(attemptId);
            if (existing != null)
                return;

            var quizResult=new QuizResult();
            quizResult.UserId=userId;
            quizResult.ProfessionId=professionId;
            quizResult.QuizAttemptId=attemptId;
            quizResult.CreatedAt=DateTime.UtcNow;
            
            await _quizResultRepository.AddAsync(quizResult);
        }
    }
}
