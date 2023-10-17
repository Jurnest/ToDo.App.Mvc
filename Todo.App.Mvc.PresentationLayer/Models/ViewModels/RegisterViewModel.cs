using System.ComponentModel.DataAnnotations;

namespace Todo.App.Mvc.PresentationLayer.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords are doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}
