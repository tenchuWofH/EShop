using EShopApi.Context;
using EShopApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace EShopApi.Services
{
    public class MockProductRepository : IProductRepository
    {
        private IEnumerable<Product> products =>
            new List<Product>
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

        public MockProductRepository()
        {
            
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            return Task.FromResult(products);
        }

        public Task<Product> GetProductAsync(long ProductId)
        {
            return Task.FromResult(products.Where(p => p.ProductId == ProductId).FirstOrDefault());
        }

        public Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<long> ProductIds)
        {
            return Task.FromResult(products.Where(p => ProductIds.Contains(p.ProductId)));
        }

        public void AddProduct(Product ProductToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryAsync(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetProductCategoryAsync(long ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VirtualizeResponse<Product>> GetProductsAsync(ProductParameters productParams)
        {
            var totalSize = products.Count();
            var items = products
                .OrderBy(p => p.ProductName)
                .Skip(productParams.StartIndex)
                .Take(productParams.PageSize)
                .ToList();

            return Task.FromResult(new VirtualizeResponse<Product> { Items = items, TotalSize = totalSize });
        }
    }
}
