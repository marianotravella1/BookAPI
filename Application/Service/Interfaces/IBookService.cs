using Domain.Entities;
using Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IBookService
    {
        // Métodos que retornan DTOs
        Task<BookResponseDto?> GetBookByIdAsync(int id);
        Task<IEnumerable<BookResponseDto>> GetAllBooksAsync();
        Task<IEnumerable<BookResponseDto>> SearchBooksAsync(BookSearchDto searchDto);
        Task<BookResponseDto?> GetBookWithAuthorsAsync(int bookId);
        
        // Métodos CRUD con DTOs
        Task<BookResponseDto> CreateBookAsync(CreateBookDto createBookDto);
        Task<BookResponseDto> UpdateBookAsync(int id, UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id);
        
        // Métodos de utilidad
        Task<bool> BookExistsAsync(int id);
        
        // Métodos adicionales con DTOs
        Task<IEnumerable<BookResponseDto>> GetBooksByAuthorAsync(int authorId);
        Task<IEnumerable<BookResponseDto>> GetBooksByRatingAsync(decimal minRating);
        Task<IEnumerable<BookResponseDto>> SearchBooksByTitleAsync(string title);
    }
}
