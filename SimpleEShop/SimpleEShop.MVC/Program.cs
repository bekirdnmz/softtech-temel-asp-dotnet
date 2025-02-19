using Microsoft.EntityFrameworkCore;
using SimpleEshop.Application.Services;
using SimpleEshop.Domain.Contracts;
using SimpleEshop.Infrastructure.Data;
using SimpleEshop.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<SimpleEshopDbContext>(options=>options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "category",
    pattern: "{category?}/Sayfa{pageNo}",
    defaults: new { controller = "Home", action = "Index", pageNo = 1, }
    );


app.MapControllerRoute(
    name:"paging",
    pattern:"Sayfa{pageNo}",
    defaults: new { controller = "Home", action = "Index", pageNo=1}

    );



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
