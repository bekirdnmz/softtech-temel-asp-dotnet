using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleEshop.Domain;
using SimpleEShop.MVC.Models;

namespace SimpleEShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var fakeProducts = new List<Product>()
            {

                //Fake data:
                new Product()
                {
                    Id = 1,
                    Name = "Iphone 12",
                    Description = "Apple Iphone 12 64 GB",
                    Price = 10000,
                    Stock = 100,
                    Rating = 5,
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },

                new Product()
                {
                    Id = 2,
                    Name = "Samsung Galaxy S21",
                    Description = "Samsung Galaxy S21 128 GB",
                    Price = 9000,
                    Stock = 50,
                    Rating = 4,
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },

                new Product()
                {
                    Id = 3,
                    Name = "Huawei P40",
                    Description = "Huawei P40 128 GB",
                    Price = 8000,
                    Stock = 30,
                    Rating = 3,
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },

                new Product()
                {
                    Id = 4,
                    Name = "Xiaomi Mi 11",
                    Description = "Xiaomi Mi 11 128 GB",
                    Price = 7000,
                    Stock = 20,
                    Rating = 2,
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },

                new Product()
                {
                    Id = 5,
                    Name = "Oppo Find X3",
                    Description = "Oppo Find X3 128 GB",
                    Price = 6000,
                    Stock = 10,
                    Rating = 1,
                
                    CategoryId = 1,
                    CreatedDate = DateTime.Now
                },

                new Product()
                {
                    Id = 6,
                    Name = "OnePlus 9",
                    Description = "OnePlus 9 128 GB",
                    Price = 5000,
                    Stock = 5,
                    Rating = 1,
                
                    CategoryId = 1,
                    CreatedDate = DateTime.Now

                }


            };
            return View(fakeProducts);
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
