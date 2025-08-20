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
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title is required.");

            if (book.Rating < 0 || book.Rating > 10)
                throw new ArgumentException("Rating must be between 0 and 10.");

            return await _bookRepository.AddAsync(book);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            // Verificar que el libro existe sin rastrearlo
            var bookExists = await _bookRepository.ExistsAsync(book.Id);
            if (!bookExists)
                throw new ArgumentException("Book not found.");

            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title is required.");

            if (book.Rating < 0 || book.Rating > 10)
                throw new ArgumentException("Rating must be between 0 and 10.");

            // Actualizar la fecha de modificación
            book.UpdatedAt = DateTime.UtcNow;

            // Usar UpdateAsync del repositorio que maneja el tracking correctamente
            return await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new ArgumentException("Book not found.");

            await _bookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await _bookRepository.GetBooksByAuthorAsync(authorId);
        }

        public async Task<IEnumerable<Book>> GetBooksByRatingAsync(int minRating)
        {
            return await _bookRepository.GetBooksByRatingAsync(minRating);
        }

        public async Task<IEnumerable<Book>> SearchBooksByTitleAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Search title cannot be empty.");

            return await _bookRepository.SearchBooksByTitleAsync(title);
        }

        public async Task<Book?> GetBookWithAuthorsAsync(int bookId)
        {
            return await _bookRepository.GetBookWithAuthorsAsync(bookId);
        }

        public async Task<bool> BookExistsAsync(int id)
        {
            return await _bookRepository.ExistsAsync(id);
        }
    }
}
