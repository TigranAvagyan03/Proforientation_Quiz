using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proforientation_Quiz.Models;
using Proforientation_Quiz.Services.Interfaces;

namespace Proforientation_Quiz.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IQuizService _quizService;
        private readonly UserManager<User> _userManager;

        public IndexModel(IQuizService quizService, UserManager<User> userManager)
        {
            _quizService = quizService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            var lastAttempt = await _quizService.GetLastAttemptAsync(userId!);

            if (lastAttempt != null && lastAttempt.CompletedAt != null)
            {
                return RedirectToPage("/Result");
            }

            return RedirectToPage("/Quiz");
        }
    }
}
