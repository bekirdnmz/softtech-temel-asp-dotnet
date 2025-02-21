using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SimpleEshop.API.MVCTemplate.Extensions;
using SimpleEshop.Application.Services;
using SimpleEshop.Domain.Contracts;
using SimpleEshop.Infrastructure.Data;
using SimpleEshop.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddServices(connectionString);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "server",
                        ValidAudience = "client",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key-for-jwt-token@345"))
                    };
                });

builder.Services.AddCors(options => options.AddPolicy("Allow", builder =>
{
    /*
     * originler:
     * 
     * http://www.softtech.com
     * https://www.softtech.com
     * https://accounts.softtech.com
     * https://www.softtech.com:655
     */

    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Allow");
app.UseAuthentication();
app.UseAuthorization();

//app.Cac

app.MapControllers();

app.Run();
