using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Application.Services;
using SimpleEshop.Domain;

namespace SimpleEShop.MVC.Controllers
{
    public class ProductsController(IProductService productService, ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var products = await productService.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await getCategoriesForSelectList();
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> getCategoriesForSelectList()
        {
            var categories = await categoryService.GetCategoriesAsync();
            return categories.Select(c => new SelectListItem(c.Name, c.Id.ToString()));


        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProduct product)
        {
            if (ModelState.IsValid)
            {
                var lastId = await productService.CreateProduct(product);
                return RedirectToAction("Index");
            }
            ViewBag.Categories = await getCategoriesForSelectList();
            return View(product);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductById(id);
            ViewBag.Categories = await getCategoriesForSelectList();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductEditDisplay editingRequest)
        {
            if ( id==editingRequest.Id && await productService.IsExists(id))
            {
                if (ModelState.IsValid)
                {
                    await productService.Edit(editingRequest);
                    return RedirectToAction("Index");
                }
            }
          
            ViewBag.Categories = await getCategoriesForSelectList();
            return View(editingRequest);
        }
    }
}
