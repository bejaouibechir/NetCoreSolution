using AspNetCoreIdentityImpl.Data;
using AspNetCoreIdentityImpl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetCoreIdentityImpl.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, 
            RoleManager<IdentityRole> roleManager,ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        async public Task<IActionResult> Register(RegisterViewModel model)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            if (ModelState.IsValid)
            {

                IdentityResult result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddPasswordAsync(user, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View("Error");
                }
            }
            return View("Error");
        }

       public IActionResult Login()
       {
            return View();
       }

        [HttpPost]
        async public Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
                if(user == null) { 
                   HttpContext.Response.StatusCode = 404;
                }

                var role = _userManager.GetRolesAsync(user);

                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToAction("Index", "Home");
            }
            return View("Error");
        }

        async public Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Role()
        {
            return View();
        }

        [HttpPost]
        async public Task<IActionResult> Role(RegisterViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                IdentityUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    HttpContext.Response.StatusCode = 404;
                }
                switch (model.Role)
                {
                    case Roles.Admin:
                        {
                            await _userManager.AddToRoleAsync(user, "Admin");
                        }
                        break;
                    case Roles.User:
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                        }
                        break;
                    case Roles.Moderator:
                        {
                            await _userManager.AddToRoleAsync(user, "Moderator");
                        }
                        break;
                    default:
                        {
                            await _userManager.AddToRoleAsync(user, "User");
                        }
                        break;
                }

                
                return RedirectToAction("Index", "Home");
            }
            return View("Error");

        }

    }
}
