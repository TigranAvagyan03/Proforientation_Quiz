using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proforientation_Quiz.Domain.Models;
using Proforientation_Quiz.Infrastructure.Identity;
using Proforientation_Quiz.Web.Pages.Account.InputModels;
using System.Runtime.CompilerServices;

namespace Proforientation_Quiz.Web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;

        public LoginModel(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }
        [BindProperty]
        public LoginInputModel Input { get; set; }

        public string ReturnUrl { get; set; }=string.Empty;
        public void OnGet(string returnUrl=null!)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync (string returnUrl = null!) 
        {
             returnUrl ??= Url.Content("~/");

            if(!ModelState.IsValid)
                return Page();

            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password,isPersistent:false, lockoutOnFailure: false);
            if (result.Succeeded) 
                return LocalRedirect(returnUrl);

            ModelState.AddModelError(string.Empty, "Неверный email или пароль.");
            return Page();
        }
    }
}
