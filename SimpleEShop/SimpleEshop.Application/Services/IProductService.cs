using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Domain;

namespace SimpleEshop.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductSummaryDisplay>> GetProducts();

        Task<List<ProductSummaryDisplay>> GetProductsByCategory(int categoryId);

        Task<int> CreateProduct(CreateNewProduct product);

        Task Edit(ProductEditDisplay editingRequest);

        Task<bool> IsExists(int id);

        Task<ProductEditDisplay> GetProductById(int id);

        Task<ProductForBasketItem> GetProductForBasketItem(int id);
    }
}