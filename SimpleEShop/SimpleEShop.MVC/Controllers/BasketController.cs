using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleEshop.Application.Services;
using SimpleEShop.MVC.Extensions;
using SimpleEShop.MVC.Models;

namespace SimpleEShop.MVC.Controllers
{
    public class BasketController(IProductService productService) : Controller
    {
        public IActionResult Index()
        {
            var cardCollection = getCollectionFromSession();
            return View(cardCollection);
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(AddingProduct addingProduct)
        {
            var product = await productService.GetProductForBasketItem(addingProduct.ProductId);

            ProductCardCollection cardCollection = getCollectionFromSession();
            cardCollection.Add(product);
            addToSession(cardCollection);


            return Json(new { message = $"{product.Name} isimli Ürün Başarıyla sepete eklendi " });
        }

      

        private ProductCardCollection getCollectionFromSession()
        {
            //var jsonString = HttpContext.Session.GetString("basket");
            //var cardCollection = new ProductCardCollection();
            ////return string.IsNullOrEmpty(jsonString) ? new ProductCardCollection() 
            //                                        : JsonConvert.DeserializeObject<ProductCardCollection>(jsonString);


            return HttpContext.Session.GetJson<ProductCardCollection>("basket") ?? new ProductCardCollection();


        }

        private void addToSession(ProductCardCollection cardCollection)
        {
          HttpContext.Session.SetJson("basket", cardCollection);

        }
    }
}
