using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<IEnumerable<Category>> GetCategoriesWithBooksAsync();
        Task<Category?> GetCategoryWithBooksAsync(int categoryId);
        Task<bool> CategoryExistsByNameAsync(string name);
    }
}