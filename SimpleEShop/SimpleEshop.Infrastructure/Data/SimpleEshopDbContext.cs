using Microsoft.EntityFrameworkCore;
using SimpleEshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEshop.Infrastructure.Data
{
    public class SimpleEshopDbContext : DbContext
    {

        public SimpleEshopDbContext(DbContextOptions<SimpleEshopDbContext> options):base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=SimpleEshopDb;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(10,2)");
            modelBuilder.Entity<Product>().Property(p => p.ImageUrl).HasDefaultValue("https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/iphone-12-blue-select-2020?wid=940&hei=1112&fmt=png-alpha&.v=1604343704000");

            modelBuilder.Entity<Product>().HasOne(p=>p.Category)
                                          .WithMany(c=>c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            //create seed  data for category table:

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Elektronik", Description = "Electronic products" },
                new Category { Id = 2, Name = "Giyim", Description = "Clothing products" },
                new Category { Id = 3, Name = "Kitap", Description = "Book products" }
                );

            //create seed data for product table. Five products for each categories:


            //create seed data for product table. Five products for each category:
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Akıllı Telefon", Description = "Son model akıllı telefon", Price = 999.99m, Stock = 50, Rating = 5, ImageUrl = null, CategoryId = 1 },
                new Product { Id = 2, Name = "Laptop", Description = "Yüksek performanslı laptop", Price = 2999.99m, Stock = 30, Rating = 4, ImageUrl = null, CategoryId = 1 },
                new Product { Id = 3, Name = "Kulaklık", Description = "Kablosuz kulaklık", Price = 199.99m, Stock = 100, Rating = 4, ImageUrl = null, CategoryId = 1 },
                new Product { Id = 4, Name = "Akıllı Saat", Description = "Fitness takibi yapan akıllı saat", Price = 499.99m, Stock = 75, Rating = 5, ImageUrl = null, CategoryId = 1 },
                new Product { Id = 5, Name = "Tablet", Description = "Taşınabilir tablet", Price = 1499.99m, Stock = 40, Rating = 4, ImageUrl = null, CategoryId = 1 },

                new Product { Id = 6, Name = "Tişört", Description = "Pamuklu tişört", Price = 49.99m, Stock = 200, Rating = 5, ImageUrl = null, CategoryId = 2 },
                new Product { Id = 7, Name = "Kot Pantolon", Description = "Şık kot pantolon", Price = 199.99m, Stock = 150, Rating = 4, ImageUrl = null, CategoryId = 2 },
                new Product { Id = 8, Name = "Kaban", Description = "Kışlık kaban", Price = 399.99m, Stock = 80, Rating = 5, ImageUrl = null, CategoryId = 2 },
                new Product { Id = 9, Name = "Ayakkabı", Description = "Rahatsız ayakkabı", Price = 299.99m, Stock = 60, Rating = 4, ImageUrl = null, CategoryId = 2 },
                new Product { Id = 10, Name = "Şapka", Description = "Güneşten koruyan şapka", Price = 29.99m, Stock = 120, Rating = 5, ImageUrl = null, CategoryId = 2 },

                new Product { Id = 11, Name = "Roman", Description = "Gizemli bir roman", Price = 19.99m, Stock = 300, Rating = 5, ImageUrl = null, CategoryId = 3 },
                new Product { Id = 12, Name = "Bilim Kurgu Kitabı", Description = "Geleceği anlatan kitap", Price = 29.99m, Stock = 250, Rating = 4, ImageUrl = null, CategoryId = 3 },
                new Product { Id = 13, Name = "Kısa Hikaye Kitabı", Description = "Kısa hikayelerden oluşan kitap", Price = 15.99m, Stock = 200, Rating = 4, ImageUrl = null, CategoryId = 3 },
                new Product { Id = 14, Name = "Çocuk Kitabı", Description = "Çocuklar için eğlenceli kitap", Price = 24.99m, Stock = 150, Rating = 5, ImageUrl = null, CategoryId = 3 },
                new Product { Id = 15, Name = "Tarih Kitabı", Description = "Geçmişi anlatan kitap", Price = 39.99m, Stock = 100, Rating = 4, ImageUrl = null, CategoryId = 3 }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
