using System.ComponentModel.DataAnnotations;

namespace CleanArch.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid format email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, ErrorMessage = "The password must be at least 8 and 20 max caracters long.")]
        [MinLength(8, ErrorMessage = "The password must be at least 8 and 20 max caracters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
