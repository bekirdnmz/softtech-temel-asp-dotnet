using Microsoft.EntityFrameworkCore;
using SimpleEshop.Domain;
using SimpleEshop.Domain.Contracts;
using SimpleEshop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEshop.Infrastructure.Repositories
{
    public class CategoryRepository(SimpleEshopDbContext dbContext) : ICategoryRepository
    {
        public Task CreateAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           return await dbContext.Categories.ToListAsync();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
