using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IBookService
    {
        Task<Book?> GetBookByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByRatingAsync(int minRating);
        Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title);
        Task<Book?> GetBookWithAuthorsAsync(int bookId);
        Task<bool> BookExistsAsync(int id);
    }
}
