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
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(BookAPIContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _dbSet
                .Where(b => b.Authors.Any(a => a.Id == authorId))
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByRatingAsync(int minRating)
        {
            return await _dbSet
                .Where(b => b.Rating >= minRating)
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title)
        {
            return await _dbSet
                .Where(b => b.Title.Contains(title))
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<Book?> GetBookWithAuthorsAsync(int bookId)
        {
            return await _dbSet
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == bookId);
        }
    }
}
