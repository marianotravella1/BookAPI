using Application.Models.DTOs;
using Application.Mappers;
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

        public async Task<AuthorDetailResponseDto?> GetAuthorByIdAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author != null ? AuthorMapper.ToDetailResponseDto(author) : null;
        }

        public async Task<IEnumerable<AuthorDetailResponseDto>> GetAllAuthorsAsync()
        {
            var authors = await _authorRepository.GetAllAsync();
            return AuthorMapper.ToDetailResponseDtos(authors);
        }

        public async Task<AuthorDetailResponseDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
        {
            var author = AuthorMapper.ToEntity(createAuthorDto);
            var createdAuthor = await _authorRepository.AddAsync(author);
            return AuthorMapper.ToDetailResponseDto(createdAuthor);
        }

        public async Task<AuthorDetailResponseDto> UpdateAuthorAsync(int id, UpdateAuthorDto updateAuthorDto)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(id);
            if (existingAuthor == null)
                throw new ArgumentException("Author not found.");

            AuthorMapper.UpdateEntity(existingAuthor, updateAuthorDto);
            var updatedAuthor = await _authorRepository.UpdateAsync(existingAuthor);
            return AuthorMapper.ToDetailResponseDto(updatedAuthor);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
                throw new ArgumentException("Author not found.");

            await _authorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AuthorDetailResponseDto>> GetAuthorsByBookAsync(int bookId)
        {
            var authors = await _authorRepository.GetAuthorsByBookAsync(bookId);
            return AuthorMapper.ToDetailResponseDtos(authors);
        }

        public async Task<AuthorDetailResponseDto?> GetAuthorWithBooksAsync(int authorId)
        {
            var author = await _authorRepository.GetAuthorWithBooksAsync(authorId);
            return author != null ? AuthorMapper.ToDetailResponseDto(author) : null;
        }

        public async Task<IEnumerable<AuthorDetailResponseDto>> SearchAuthorsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Search name cannot be empty.");

            var authors = await _authorRepository.SearchAuthorsByNameAsync(name);
            return AuthorMapper.ToDetailResponseDtos(authors);
        }

        public async Task<bool> AuthorExistsAsync(int id)
        {
            return await _authorRepository.ExistsAsync(id);
        }
    }
}
