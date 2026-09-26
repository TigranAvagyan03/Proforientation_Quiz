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
    public class ResultModel : PageModel
    {

        private readonly UserManager<User> _userManager;
        private readonly IQuizService _quizService;
        private readonly IProfessionService _professionService;

        public ResultModel(UserManager<User> userManager, IQuizService quizService, IProfessionService professionService)
        {
            _userManager = userManager;
            _quizService = quizService;
            _professionService = professionService;
        }
      
        public Profession? Profession { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            var attempt= await _quizService.GetLastAttemptAsync(userId!);
            if (attempt == null)
                return RedirectToPage("/Quiz");
            bool completed=await _quizService.IsQuizCompletedAsync(attempt.Id);
            if (!completed) 
                return RedirectToPage("/Quiz");

            Profession= await _professionService.GetUserProfessionAsync(attempt.Id);

            if (Profession != null)
            {
                await _professionService.SaveQuizResultAsync(userId!, Profession.Id,attempt.Id);
            }

            return Page();
        }
        public async Task<IActionResult> OnPostRestartAsync()
        {
            var userId = _userManager.GetUserId(User);
            await _quizService.StartNewAttemptAsync(userId!);
            return RedirectToPage("/Quiz");
        }
    }
}
