using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebRazor
{
    public class LoginViewModel
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}