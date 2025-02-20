using Microsoft.EntityFrameworkCore;
using SimpleEshop.Application.Services;
using SimpleEshop.Domain.Contracts;
using SimpleEshop.Infrastructure.Data;
using SimpleEshop.Infrastructure.Repositories;

namespace SimpleEshop.API.MVCTemplate.Extensions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();

            services.AddDbContext<SimpleEshopDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
