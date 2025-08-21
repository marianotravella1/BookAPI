using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookAPIContext context) : base(context)
        {
        }

        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithBooksAsync()
        {
            return await _dbSet
                .Include(c => c.Books)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryWithBooksAsync(int categoryId)
        {
            return await _dbSet
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await _dbSet
                .AnyAsync(c => c.Name.ToLower() == name.ToLower());
        }
    }
}