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
    public class CategoryRepository : ICategoryRepository
    {
        private EShopContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CategoryRepository> _logger;
        //private CancellationTokenSource _cancellationTokenSource;

        public CategoryRepository(EShopContext context,
            IHttpClientFactory httpClientFactory,
            ILogger<CategoryRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int CategoryId)
        {
            return await _context.Categories.Where(c => c.CategoryId == CategoryId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync(IEnumerable<int> CategoryIds)
        {
            return await _context.Categories.Where(p => CategoryIds.Contains(p.CategoryId)).ToListAsync();
        }

        public void AddCategory(Category CategoryToAdd)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
