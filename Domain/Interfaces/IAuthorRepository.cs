using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsByBookAsync(int bookId);
        Task<Author?> GetAuthorWithBooksAsync(int authorId);
        Task<IEnumerable<Author>> SearchAuthorsByNameAsync(string name);
    }
}
