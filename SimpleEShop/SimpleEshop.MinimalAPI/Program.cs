using FluentValidation;
using SimpleEshop.Application.DataTransferObjects;
using SimpleEshop.MinimalAPI.Extensions;
using SimpleEshop.MinimalAPI.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<CreateNewProduct>, CreateNewProductValidator>();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddServices(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddEndPoints();
app.Run();
