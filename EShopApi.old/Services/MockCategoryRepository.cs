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
    public class MockCategoryRepository : ICategoryRepository
    {
        private IEnumerable<Category> categories =>
            new List<Category>
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

        public MockCategoryRepository()
        {
            
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return Task.FromResult(categories);
        }

        public Task<Category> GetCategoryAsync(int CategoryId)
        {
            return Task.FromResult(categories.Where(c => c.CategoryId == CategoryId).FirstOrDefault());
        }

        public Task<IEnumerable<Category>> GetCategoriesAsync(IEnumerable<int> CategoryIds)
        {
            return Task.FromResult(categories.Where(p => CategoryIds.Contains(p.CategoryId)));
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
