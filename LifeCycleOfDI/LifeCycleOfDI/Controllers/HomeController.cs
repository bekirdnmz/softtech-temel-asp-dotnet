using System.Diagnostics;
using LifeCycleOfDI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LifeCycleOfDI.Controllers
{
    public class HomeController(ISingleton singleton, ITransient transient, IScoped scoped, ILogger<HomeController> logger, CustomService customService) : Controller
    { 
        

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Value;
            ViewBag.Transient = transient.Value;
            ViewBag.Scoped = scoped.Value;

            ViewBag.SingletonCustomService = customService.Singleton.Value;
            ViewBag.TransientCustomService = customService.Transient.Value;
            ViewBag.ScopedCustomService = customService.Scoped.Value;




            return View();
        }

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
