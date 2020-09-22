using EShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopApi.Services
{
    public interface IProductRepository
    {
        //IEnumerable<Product> GetProducts();

        //Product GetProduct(long id);

        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(long ProductId);

        Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<long> ProductIds);

        Task<Category> GetCategoryAsync(int CategoryId);

        Task<IEnumerable<Category>> GetProductCategoryAsync(long ProductId);

        void AddProduct(Product ProductToAdd);

        Task<bool> SaveChangesAsync();
    }
}
