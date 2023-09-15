using System.Configuration;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string connstring = ConfigurationManager.ConnectionStrings["defaultconnection"].ConnectionString;


            return View();
        }

   
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}