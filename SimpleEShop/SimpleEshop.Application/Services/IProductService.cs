using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Domain;

namespace SimpleEshop.Application.Services
{
    public interface IProductService
    {
        List<ProductSummaryDisplay> GetProducts();
    }
}