using FluentValidation;
using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.Application.Services;

namespace SimpleEshop.MinimalAPI.Extensions
{
    public static class EndpointExtensions
    {
        public static void AddEndPoints(this WebApplication app)
        {

            var productsGroup = app
                                   .MapGroup("/products");
                                   
                             

            productsGroup.MapGet("/", async (IProductService product) =>
            {
                return Results.Ok(await product.GetProducts());
            }).WithDescription("Bu endpoint, tüm ürünleri getirir")
              .WithDisplayName("TumUrunleriGetir");
             
            productsGroup.MapGet("/{id}", async (IProductService product, int id) =>
            {
                return Results.Ok(await product.GetProductById(id));
            }).WithDescription("Bu endpoint, id'si verilen ürünü getirir")
              .WithDisplayName("UrunGetir");

            productsGroup.MapPost("/", async (IProductService product, IValidator<CreateNewProduct> validator, CreateNewProduct newProduct) =>
            {
                var validationResult = await validator.ValidateAsync(newProduct);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(new
                    {
                        message = validationResult.Errors.Select(
                        e => new { e.PropertyName, e.ErrorMessage }).ToList()
                    });
                }
                return Results.Created($"/products/{await product.CreateProduct(newProduct)}", newProduct);
            }).WithDescription("Bu endpoint, yeni ürün ekler")
              .WithDisplayName("YeniUrunEkle");

            productsGroup.MapPut("/{id}",async(IProductService productService, ProductEditDisplay request) =>
            {
                await productService.Edit(request);
                return Results.Ok();
            }).WithDescription("Bu endpoint, id'si verilen ürünü günceller")
              .WithDisplayName("UrunGuncelle");




        }
    }
}
