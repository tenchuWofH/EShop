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
    public class ProductRepository : IProductRepository
    {
        private EShopContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ProductRepository> _logger;
        //private CancellationTokenSource _cancellationTokenSource;

        public ProductRepository(EShopContext context,
            IHttpClientFactory httpClientFactory,
            ILogger<ProductRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(b => b.Category).ToListAsync();
        }

        public async Task<Product> GetProductAsync(long ProductId)
        {
            return await _context.Products.Where(p => p.ProductId == ProductId).Include(b => b.Category).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(IEnumerable<long> ProductIds)
        {
            return await _context.Products.Where(p => ProductIds.Contains(p.ProductId)).Include(b => b.Category).ToListAsync();
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
    }
}
