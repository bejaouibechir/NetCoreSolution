using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Unity;
using WebMVCore.Services;

namespace WebMVCore.Controllers
{
    public class UnityController : Controller
    {
        private readonly IUnityContainer _container;

        public UnityController(IUnityContainer container)
        {
            _container = container;
        }

        public IActionResult Index()
        {
            _container.RegisterType<ICar, Audi>();
            _container.RegisterType<ICar, Mercedes>();
            _container.RegisterType<ICar, BMW>();

            var audi = _container.Resolve<Audi>();
            var mercedes = _container.Resolve<Mercedes>();
            var bmw = _container.Resolve<BMW>();


            Debug.WriteLine(audi.ToString());
            Debug.WriteLine(mercedes.ToString());
            Debug.WriteLine(bmw.ToString());

            return View();
        }
    }
}
