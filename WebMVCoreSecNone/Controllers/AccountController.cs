using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebMVCoreSecNone.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }
        
        [HttpPost]
        async public Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                /* Operation de verification de l'utilisateur auprès de
                 * la base de données*/
                if(model.Login != "admin" &&  model.Password != "admin") {
                    /*L'utilisateur n'est pas authentifié*/
                    HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                }

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, model.Login),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Email,"admin@xyz.com")
                };
                var identity = new ClaimsIdentity(claims, 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults
                    .AuthenticationScheme, principal);
               
                return RedirectToAction("Index", "Home");

            }

            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View();
        }

        public IActionResult UnAuthorized()
        {
            return View();
        }


    }
}
