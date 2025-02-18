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
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        public async Task<IEnumerable<CategoryMenuDisplay>> GetCategoriesAsync()
        {
            var categories = await categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryMenuDisplay
            {
                Id = c.Id,
                Name = c.Name
            });
        }
    }
}
