//#define shared
//#define normal
//#define noaction
#define viewparam

using Microsoft.AspNetCore.Mvc;
using WebMVCore.Models;

namespace WebMVCore.Controllers
{
    public class ProductController : Controller
    {

        [ActionName("Index")]
        public ActionResult GetIndex()
        {
            //Provoquer une erreur interne du serveur
            Response.StatusCode = 500;

#if shared
            if(Response.StatusCode==500)
            {
                return View("Error", new ErrorViewModel
                {
                     RequestId = Guid.NewGuid().ToString()
                });
            }
#endif

#if normal
            if (Response.StatusCode == 500)
            {
                    return Redirect("Error");
            }
#endif
#if viewparam
            if (Response.StatusCode == 500)
            {
                return new RedirectToActionResult("Test", "Product", new
                Point{
                    X = 1,Y = 2
                });
            }
#endif

            return View();
        }


        public ActionResult Test(Point point) {
           
            ViewBag.point = point;    
            return View();
        }


        public ActionResult Error()
        {
            return View();
        }

#if noaction
        [NonAction]
#endif
        public ActionResult Json()
        {
            return new JsonResult(
                new
                {
                    Nom="Mercedes", VI="12345"
                });
        }

        
        public ActionResult Empty(int id)
        {
            if (id == 0)
                return new EmptyResult();
            else return Content("<h1> Ce ci n'est pas une vue vide");
        }
         
        
         //public ContentResult Index()
         //{
         //       return Content("<h3>Here's a custom content header</h3>", 
         //           "text/html", System.Text.Encoding.UTF8);
         //}
        


        /*async public Task<IActionResult> Index()
        {
           
            var result = await GetDataAsync();
            
            return View();
        }*/

        async public Task<List<string>> GetDataAsync()
        {
            await Task.Delay(3000);
            return new List<string>
            {
                "One","Two","Three"
            };
        }
    }
}
