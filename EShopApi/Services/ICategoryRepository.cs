using EShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShopApi.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();

        Task<Category> GetCategoryAsync(int CategoryId);

        Task<IEnumerable<Category>> GetCategoriesAsync(IEnumerable<int> CategoryIds);

        void AddCategory(Category CategoryToAdd);

        Task<bool> SaveChangesAsync();
    }
}
