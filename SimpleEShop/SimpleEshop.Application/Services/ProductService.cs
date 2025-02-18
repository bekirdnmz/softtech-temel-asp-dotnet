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

        public List<ProductSummaryDisplay> GetProducts()
        {
            var fakeProducts = _productRepository.GetAllAsync().Result;
       


            var summaries = fakeProducts.Select(p => new ProductSummaryDisplay()
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
    }
}
