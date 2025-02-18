using SimpleEshop.Application.DataTransferObjects;

namespace SimpleEshop.Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryMenuDisplay>> GetCategoriesAsync();
    }
}