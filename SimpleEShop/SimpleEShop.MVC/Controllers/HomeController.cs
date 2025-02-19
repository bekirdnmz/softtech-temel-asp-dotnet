using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleEshop.Application.Services;
using SimpleEshop.Domain;
using SimpleEShop.MVC.Models;

namespace SimpleEShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public async Task<IActionResult> Index(int pageNo=1, int? category = null)
        {
            //instance almak artık HomeController'ın derdi değil.
            //var productService = new ProductService();
            var products = category.HasValue ? await productService.GetProductsByCategory(category.Value):
                                               await productService.GetProducts();

            

            var totalCount = products.Count;
            var itemsPerPage = 4;

            var startIndex = (pageNo - 1) * itemsPerPage;
            var endIndex = startIndex + itemsPerPage;

            var pagedProducts = products.Take(startIndex..endIndex).ToList();

            var totalPages = (int)Math.Ceiling((double)totalCount / itemsPerPage);


            var viewModel = new ProductListViewModel()
            {
                Products = pagedProducts,
                TotalPages = totalPages,
                CurrentPage = pageNo,
                CurrentCategory = category
            };

            //ViewBag.TotalPages = totalPages;
            return View(viewModel);
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
