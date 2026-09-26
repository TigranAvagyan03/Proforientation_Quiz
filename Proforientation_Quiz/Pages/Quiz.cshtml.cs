using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Identity;
using Proforientation_Quiz.Application.Services.Interfaces;

namespace Proforientation_Quiz.Web.Pages
{
    [Authorize]
    public class QuizModel : PageModel
    {
        private readonly IQuizService _service;
        private readonly UserManager<User> _userManager;
        public QuizModel(IQuizService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        public Question? CurrentQuestion { get; set; }
        public int AttemptId {  get; set; }
        public async Task<IActionResult> OnGetAsync ()
        {
            var userId=_userManager.GetUserId(User);
            var attempt=await _service.GetOrCreateActiveAttemptAsync(userId!);
            AttemptId=attempt.Id;
            var completed=await _service.IsQuizCompletedAsync(attempt.Id);

            if (completed)
            {
                return RedirectToPage("/Result");
            }

            CurrentQuestion =await _service.GetNextQuestionAsync(attempt.Id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int questionId, int answerId, int attemptId)
        {
            var userId= _userManager.GetUserId(User);

            await _service.SubmitAnswerAsync(userId!, questionId, answerId , attemptId);
            var completed = await _service.IsQuizCompletedAsync(attemptId);

            if (completed)
            {
                await _service.CompleteAttemptAsync(attemptId);
                return RedirectToPage("/Result");
            }
            return RedirectToPage();
        }
    }
}
