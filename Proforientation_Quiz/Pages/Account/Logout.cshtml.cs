using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Identity;

namespace Proforientation_Quiz.Web.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<User> _signInManager;

        public LogoutModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {

            await _signInManager.SignOutAsync();
            return RedirectToPage(returnUrl ?? "/Account/Login");
        }
    }
}
