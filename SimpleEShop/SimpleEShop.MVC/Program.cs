using Microsoft.AspNetCore.Authentication.Cookies;
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
builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<SimpleEshopDbContext>(options=>options.UseSqlServer(connectionString));

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Users/Login";
                    option.LogoutPath = "/Users/Logout";
                    option.AccessDeniedPath = "/Users/AccessDenied";
                    option.ReturnUrlParameter = "nereyeGideyim";

                    //option.Cookie.Expiration = TimeSpan.FromDays(3);
                });
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseSession();

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
