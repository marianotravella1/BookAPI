using Application.Models.DTOs;
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
        // Métodos que retornan DTOs
        Task<AuthorDetailResponseDto?> GetAuthorByIdAsync(int id);
        Task<IEnumerable<AuthorDetailResponseDto>> GetAllAuthorsAsync();
        Task<AuthorDetailResponseDto?> GetAuthorWithBooksAsync(int authorId);
        Task<IEnumerable<AuthorDetailResponseDto>> GetAuthorsByBookAsync(int bookId);
        Task<IEnumerable<AuthorDetailResponseDto>> SearchAuthorsByNameAsync(string name);
        
        // Métodos CRUD con DTOs
        Task<AuthorDetailResponseDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);
        Task<AuthorDetailResponseDto> UpdateAuthorAsync(int id, UpdateAuthorDto updateAuthorDto);
        Task DeleteAuthorAsync(int id);
        
        // Métodos de utilidad
        Task<bool> AuthorExistsAsync(int id);
    }
}
