using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IAuthorService
    {
        Task<Author?> GetAuthorByIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author> UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
        Task<IEnumerable<Author>> GetAuthorsByBookAsync(int bookId);
        Task<Author?> GetAuthorWithBooksAsync(int authorId);
        Task<IEnumerable<Author>> SearchAuthorsByNameAsync(string name);
        Task<bool> AuthorExistsAsync(int id);
    }
}
