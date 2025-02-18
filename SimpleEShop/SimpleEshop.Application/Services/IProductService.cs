using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Domain;

namespace SimpleEshop.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductSummaryDisplay>> GetProducts();

        Task<List<ProductSummaryDisplay>> GetProductsByCategory(int categoryId);
    }
}