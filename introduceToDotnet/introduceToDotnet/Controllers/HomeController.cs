using introduceToDotnet.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceToDotnet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //HttpResponse olarak dönebilecekler:
            //1. HTML, CSS, JS
            //2. JSON
            //3. XML
            //4. File


            //return "Şu anda Home/Index sayfasındasınız" ;
            ViewBag.Name = "Türkay";
            ViewBag.Hour = DateTime.Now.Hour;


            return View();
        }

        public IActionResult Products()
        {
            var products = new List<Product>()
            {
                new(){Id = 1, Name = "Kalem", Price = 100},
                new(){Id = 2, Name = "Silgi", Price = 100},
                new(){Id = 3, Name = "Defter", Price = 100}
            };

            return View(products);
        }

        public IActionResult Response()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Response(UserResponse userResponse)
        {
            if (ModelState.IsValid)
            {
               return View("Thanks", userResponse);
            }
            return View();
        }
    }
}
