using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proforientation_Quiz.Models;
using Proforientation_Quiz.Pages.Account.InputModels;
using System.Runtime.CompilerServices;

namespace Proforientation_Quiz.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public RegisterModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [BindProperty]
        public RegisterInputModel Input {  get; set; }

        public string ReturnUrl { get; set; }  = string.Empty;

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl=null!)
        {
            returnUrl ??= Url.Content("~/");

            if (!ModelState.IsValid) 
                return Page();

            User user=new User();
            user.UserName= Input.Email;
            user.Email= Input.Email;

            var result=await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded) 
            { 
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    }
}
