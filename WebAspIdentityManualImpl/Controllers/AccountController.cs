using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAspIdentityManualImpl.Models;

namespace WebAspIdentityManualImpl.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(ApplicationDbContext context,
            UserManager<IdentityUser>userManager,
            SignInManager<IdentityUser>signInManager,
            RoleManager<IdentityRole>roleManager)
        {
           _context = context;
           _userManager = userManager;
           _signInManager = signInManager;
           _roleManager = roleManager;
        }

        public IActionResult Register()
        {
           return View(new UserViewModel());
        }

        [HttpPost]
        async public Task<IActionResult> Register(UserViewModel model) {
          if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = model.Email,
                };
                var result = await _userManager.CreateAsync(user,model.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Home", "Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            return View(); 
        }

        public IActionResult Login()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        async public Task<IActionResult> Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _signInManager
                    .PasswordSignInAsync(model.Email, model.Password,
                    true, false);
                
                
                return View(model);
            }

            return View();
        }

        async public Task<IActionResult> Logout()
        {
            await _signInManager
                     .SignOutAsync();
            return View();
        }

    }
}
