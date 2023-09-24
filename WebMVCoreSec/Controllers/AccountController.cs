using Microsoft.AspNetCore.Mvc;

namespace WebMVCoreSec.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());  
        }

        public IActionResult Login(LoginViewModel model)
        {
           

            
            return View(model);
        }

    }
}
