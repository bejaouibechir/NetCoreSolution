//#define test


using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCore.Filters;
using WebMVCore.Models;
using WebMVCore.Services;

namespace WebMVCore.Controllers
{
    [ServiceFilter(typeof(ExceptionFilter))]
    public class HomeController : Controller
    {
        private readonly ISingletonService _singletonsrv;
        private readonly IScopedService _scopedsrv;
        private readonly ITransientService _transientsrv;
        private readonly ILogger<HomeController> _logger;

        private readonly ISession session;


        public HomeController()
        {
            
        }

        //Injection de dépendance
        public HomeController(ISingletonService singletonsrv,
            IScopedService scopedsrv, ITransientService transientsrv
            ,ILogger<HomeController> logger, 
            IHttpContextAccessor httpContextAccessor)
        {
            _singletonsrv = singletonsrv;
            _scopedsrv = scopedsrv;
            _transientsrv = transientsrv;
            _logger = logger;
            session = httpContextAccessor.HttpContext.Session;

        }


   
        public int Somme(Calcul model)
        {
            int result = model.X + model.Y + 1; //Erreur sémantique
            return result;
        }


#if test
        [Route("Home/test")]
#endif
        [ServiceFilter(typeof(LogActionFilter))]
        public IActionResult Index()
        {
            _logger.Log(LogLevel.Information,$"La méthode index est" +
                $"visitée à {DateTime.Now.Hour}:{DateTime.Now.Minute}");
            _singletonsrv.Trace();
            _scopedsrv.Trace();
            _transientsrv.Trace();
            Debug.WriteLine("\n\n");
            return View();
            //return View();
        }

        public IActionResult Somme(int x,int y)
        {
            int result = x + y;
            //ViewBag.Title = "Page de calcul";
            session.SetString("title", "Operation de calcul");
            return View();
        }


        
        public IActionResult Product(string x)
        {
            return View();
        }



        [HttpGet]
        public IActionResult Test(int y)
        {
            return View();
        }


        //[Authorize]
        public IActionResult Privacy()
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