using Microsoft.AspNetCore.Mvc;
using WebMVCore.Models;

namespace WebMVCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _accessor;


        public AccountController()
        {
            
        }

        public AccountController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }


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
        public IActionResult Login(LoginViewModel loginVm)
        {
            if(ModelState.IsValid)
            {
                //Pour simuler une erreur de serveur interne
                //HttpContext.Response.StatusCode = 500;
                //_accessor.HttpContext.Response.Cookies.Append("key1", "value1");
                //_accessor.HttpContext.Response.Cookies.Append("key2", "value2");
                //Ecrire la logique de verification de l'utilisateur

                return View(loginVm);
            }
            else
            {
                return View("Anonymous");
            }
            
           
        }
    }
}
