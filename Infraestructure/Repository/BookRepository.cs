using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookAPIContext _dbContext;

        public BookRepository(BookAPIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _dbContext.Books
                .Include(x => x.Authors)
                .ToListAsync();
        }

        public async Task<int> AddBook(Book book)
        {
            _dbContext.Books.Add(book);

            await _dbContext.SaveChangesAsync();

            return book.Id;
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
