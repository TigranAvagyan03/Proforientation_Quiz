using System.ComponentModel.DataAnnotations;

namespace Proforientation_Quiz.Pages.Account.InputModels
{
    public class AuthInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }

    public class LoginInputModel : AuthInputModel
    {
    }

    public class RegisterInputModel : AuthInputModel
    {
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
