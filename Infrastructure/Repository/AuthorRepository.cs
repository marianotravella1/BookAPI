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
    public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookAPIContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Author>> GetAuthorsByBookAsync(int bookId)
        {
            return await _dbSet
                .Where(a => a.Books.Any(b => b.Id == bookId))
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Author?> GetAuthorWithBooksAsync(int authorId)
        {
            return await _dbSet
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == authorId);
        }

        public async Task<IEnumerable<Author>> SearchAuthorsByNameAsync(string name)
        {
            return await _dbSet
                .Where(a => a.Name.Contains(name))
                .Include(a => a.Books)
                .ToListAsync();
        }
    }
}
