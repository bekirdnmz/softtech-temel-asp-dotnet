using Microsoft.AspNetCore.Mvc;
using SimpleEshop.Application.Services;

namespace SimpleEShop.MVC.ViewComponents
{
    public class MenuViewComponent(ICategoryService categoryService) : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var categories = categoryService.GetCategoriesAsync().Result;
            return View(categories);
        }
    }
}
