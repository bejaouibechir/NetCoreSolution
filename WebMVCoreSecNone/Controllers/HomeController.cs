using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCoreSecNone.Models;

namespace WebMVCoreSecNone.Controllers
{
    /*
     * Permet de verouiller l'accès à toutes les ressources sauf celles 
     * marquées avec allowanonymous
     */
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /*
         Créer un veroux sur la base d'authorisation en appliquant une 
         politique voir à partir de la ligne 17 de classe Program.cs
         */
        [Authorize(Policy = "Policy1")]
        public IActionResult ControlPanel()
        {
            return View();
        }

        /*Cet attribut ajoute une exception pour dispenser l'utlisateur
         à être vérifié avant d'accèder à la ressource*/
        [AllowAnonymous]
        public IActionResult Test()
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