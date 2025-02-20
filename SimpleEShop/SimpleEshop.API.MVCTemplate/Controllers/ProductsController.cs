using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleEshop.API.MVCTemplate.Filters;
using SimpleEshop.API.MVCTemplate.Models;
using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Application.Services;

namespace SimpleEshop.API.MVCTemplate.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Get(int id)
        {
            //if (!await productService.IsExists(id))
            //{
            //    return NotFound();
            //}
            var product = await productService.GetProductById(id);
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var products = await productService.GetProductsByCategory(categoryId);
            return Ok(products);
        }

        [HttpGet("search/{productName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Search(string productName)
        {
            var products = await productService.Search(productName);

            var searchResult = products.Count() > 0
                ? new ProductSearchResult
                {
                    TotalCount = products.Count(),
                    Products = products,
                    SearchTerm = productName,
                    Message = $"{productName} aramas sonucunda toplam {products.Count()} adet ürün bulundu"
                }
                : new ProductSearchResult
                {
                    TotalCount = 0,
                    Products = products,
                    SearchTerm = productName,
                    Message = "Arama sonucunda hiçbir ürün bulunamadı"
                };

            return Ok(searchResult);
        }

        [Authorize(Roles = "admin,editor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Post([FromBody] CreateNewProduct product)
        {

            if (ModelState.IsValid)
            {
                var productId = await productService.CreateProduct(product);
                return CreatedAtAction(nameof(Get), routeValues: new { id = productId }, value: null);
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Put(int id, [FromBody] ProductEditDisplay editingRequest)
        {
            //if (!await productService.IsExists(id))
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                await productService.Edit(editingRequest);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
            //if (!await productService.IsExists(id))
            //{
            //    return NotFound();
            //}
            await productService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}/{price}")]
        [RangeExceptionFilter(Max =5000, Min =1000)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [IsExists]
        public async Task<IActionResult> UpdatePrice(int id, decimal price)
        {
            //if (!await productService.IsExists(id))
            //{
            //    return NotFound();
            //}
            var productPrice = (await productService.GetProductById(id)).Price;

            var minPrice = productPrice * .25m;
            var maxPrice = productPrice * 2.5m;
            //fiyat min ve max değerler arasında olmalı:
            if (price < minPrice || price > maxPrice)
            {
                throw new ArgumentOutOfRangeException("price",price, $"Fiyat {minPrice} ve {maxPrice} arasında olmalıdır");
            }

            await productService.UpdateProductPrice(id, price);
            return NoContent();
        }



    }
}
