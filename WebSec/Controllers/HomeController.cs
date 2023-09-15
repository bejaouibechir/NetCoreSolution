using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebSec.Models;

namespace WebSec.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                string login = model.Login;
                string password = model.Password;

                if(login.Equals("admin") &&  password.Equals("admin"))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,login),
                        new Claim(ClaimTypes.Role,"Admin"),
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                     HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return RedirectToAction("Index", "Home"); 
                }   
            }
            return View("Login");
            
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UnAuthorized()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}