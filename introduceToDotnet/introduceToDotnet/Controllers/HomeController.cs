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
            return View();
        }
    }
}
