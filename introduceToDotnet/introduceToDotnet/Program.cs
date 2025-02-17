var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();





var app = builder.Build();
//gelen http isteğini, rotaya yönlendir:

app.UseRouting();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();
