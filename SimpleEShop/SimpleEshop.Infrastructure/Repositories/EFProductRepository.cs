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
    public class EFProductRepository(SimpleEshopDbContext dbContext) : IProductRepository
    {
        public async Task CreateAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing =  await dbContext.Products.FindAsync(id);
            dbContext.Products.Remove(existing);

        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();

        }

        public async Task<Product> GetAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
            
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
             return await dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
             return await dbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
           dbContext.Products.Update(entity);
           await dbContext.SaveChangesAsync();
        }
    }
}
