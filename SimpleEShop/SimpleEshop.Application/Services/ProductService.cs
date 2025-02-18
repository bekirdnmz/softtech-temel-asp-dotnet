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
    }
}
