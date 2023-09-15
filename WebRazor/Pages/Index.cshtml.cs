using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace WebRazor.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Login { get; set; }

        public void OnPost()
        {
            Debug.WriteLine(Login.Login);
            Debug.WriteLine(Login.Password);
        }
    }
}