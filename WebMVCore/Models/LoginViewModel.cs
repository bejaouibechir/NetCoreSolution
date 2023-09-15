using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebMVCore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Il faut pas laisser le champ Login vide")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Il faut pas laisser le Password  vide")]
        [PasswordPropertyText]
        public string Password { get; set; }
        
        [PasswordPropertyText]
        [Required(ErrorMessage = "Il faut pas laisser le Confirm password  vide")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public Operations Operations { get; set; }
    }

    public enum Operations
    {
        Approve,Forbid,Test
    };
}
