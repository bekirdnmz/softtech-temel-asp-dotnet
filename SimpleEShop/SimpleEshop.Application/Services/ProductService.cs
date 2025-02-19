using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Domain;
using SimpleEshop.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEshop.Application.Services
{
    public class ProductService(IProductRepository _productRepository) : IProductService
    {
        public async Task<int> CreateProduct(CreateNewProduct request)
        {
            var productEntity = new Product()
            {
                CategoryId = request.CategoryId,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Price = request.Price
            };
            await _productRepository.CreateAsync(productEntity);
            return productEntity.Id;
        }

        public Task Edit(ProductEditDisplay editingRequest)
        {
            var product = new Product()
            {
                CategoryId = editingRequest.CategoryId,
                Description = editingRequest.Description,
                Id = editingRequest.Id,
                ImageUrl = editingRequest.ImageUrl,
                Name = editingRequest.Name,
                Price = editingRequest.Price,
                Stock = editingRequest.Stock

            };

            return _productRepository.UpdateAsync(product);
        }

        public async Task<ProductEditDisplay> GetProductById(int id)
        {
            var product = await _productRepository.GetAsync(id);
            return new ProductEditDisplay()
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

        }

        public async Task<ProductForBasketItem> GetProductForBasketItem(int id)
        {
           var product = await _productRepository.GetAsync(id);
            return new ProductForBasketItem()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl
            };
        }

        //Bu uygulama, entity'ler ile ne yapılacağını belirleyen servislerden oluşacak.
        //Bu uygulamada, product varlığıyla ....... işlemleri yapılacak.

        //private readonly IProductRepository _productRepository;


        //public ProductService(IProductRepository productRepository)
        //{
        //    _productRepository = productRepository;
        //}

        public async Task<List<ProductSummaryDisplay>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
       


            var summaries = products.Select(p => new ProductSummaryDisplay()
            {
                CategoryId = p.CategoryId,
                Description = p.Description,
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price
            }).ToList();
            return summaries;
        }

        public async Task<List<ProductSummaryDisplay>> GetProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategoryIdAsync(categoryId);

            return products.Select(p => new ProductSummaryDisplay()
            {
                CategoryId = p.CategoryId,
                Description = p.Description,
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                Price = p.Price
            }).ToList();
        }

        public async Task<bool> IsExists(int id)
        {
           return await _productRepository.IsExists(id);
        }
    }
}
