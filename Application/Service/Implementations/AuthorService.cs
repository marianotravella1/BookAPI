using Application.Models.Requests;
using Application.Service.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> CreateAuthorAsync(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Author name is required.");

            return await _authorRepository.AddAsync(author);
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(author.Id);
            if (existingAuthor == null)
                throw new ArgumentException("Author not found.");

            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Author name is required.");

            return await _authorRepository.UpdateAsync(author);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new ArgumentException("Author not found.");

            await _authorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAuthorsByBookAsync(int bookId)
        {
            return await _authorRepository.GetAuthorsByBookAsync(bookId);
        }

        public async Task<Author?> GetAuthorWithBooksAsync(int authorId)
        {
            return await _authorRepository.GetAuthorWithBooksAsync(authorId);
        }

        public async Task<IEnumerable<Author>> SearchAuthorsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Search name cannot be empty.");

            return await _authorRepository.SearchAuthorsByNameAsync(name);
        }

        public async Task<bool> AuthorExistsAsync(int id)
        {
            return await _authorRepository.ExistsAsync(id);
        }
    }
}
