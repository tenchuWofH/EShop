using EShopApi.Context;
using EShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(this EShopContext context)
        {
            //// first, clear the database.  This ensures we can always start 
            //// fresh with each demo.  Not advised for production environments, obviously :-)
            //context.Cities.RemoveRange(context.Cities);

            //context.SaveChanges();
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            // init seed data
            var categories = new List<Category>()
            {
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Eletronics",
                    Description = "Eletronics in general"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Home",
                    Description = "Home in general"
                }
            };

            var products = new List<Product>()
            {
                new Product()
                {
                    ProductId = 1,
                    ProductName = "Celular TOP 1",
                    Description = "great celaular",
                    ProductCode = "cel01",
                    Price = 10000,
                    ReleaseDate = new DateTime(2020, 09, 22),
                    Category = new Category
                    {
                        CategoryId = 1,
                        CategoryName = "Eletronics",
                        Description = "Eletronics in general"
                    }
                },
                new Product()
                {
                    ProductId = 2,
                    ProductName = "TV 4K 1",
                    Description = "great TV",
                    ProductCode = "tv01",
                    Price = 5000,
                    ReleaseDate = new DateTime(2020, 09, 22),
                    Category = new Category
                    {
                        CategoryId = 1,
                        CategoryName = "Eletronics",
                        Description = "Eletronics in general"
                    }
                }
             };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
