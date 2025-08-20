using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<Book>> GetBooksByRatingAsync(int minRating);
        Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title);
        Task<Book?> GetBookWithAuthorsAsync(int bookId);
    }
}
