using Application.Service.Interfaces;
using Application.Models.DTOs;
using Application.Mappers;
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
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
        }

        public async Task<BookResponseDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book != null ? BookMapper.ToResponseDto(book) : null;
        }

        public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return BookMapper.ToResponseDtoList(books);
        }

        public async Task<BookResponseDto> CreateBookAsync(CreateBookDto createBookDto)
        {
            // Validar que la categoría existe si se especifica
            if (createBookDto.CategoryId.HasValue)
            {
                var categoryExists = await _categoryRepository.ExistsAsync(createBookDto.CategoryId.Value);
                if (!categoryExists)
                    throw new ArgumentException("La categoría especificada no existe.");
            }

            // Validar que todos los autores existen
            foreach (var authorId in createBookDto.AuthorIds)
            {
                var authorExists = await _authorRepository.ExistsAsync(authorId);
                if (!authorExists)
                    throw new ArgumentException($"El autor con ID {authorId} no existe.");
            }

            // Convertir DTO a entidad
            var book = BookMapper.ToEntity(createBookDto);

            // Crear el libro
            var createdBook = await _bookRepository.AddAsync(book);

            // Asignar autores
            foreach (var authorId in createBookDto.AuthorIds)
            {
                var author = await _authorRepository.GetByIdAsync(authorId);
                if (author != null)
                {
                    createdBook.Authors.Add(author);
                }
            }

            await _bookRepository.UpdateAsync(createdBook);

            // Obtener el libro completo con relaciones
            var bookWithRelations = await _bookRepository.GetBookWithAuthorsAsync(createdBook.Id);
            return BookMapper.ToResponseDto(bookWithRelations!);
        }

        public async Task<BookResponseDto> UpdateBookAsync(int id, UpdateBookDto updateBookDto)
        {
            // Verificar que el libro existe
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
                throw new ArgumentException("Libro no encontrado.");

            // Validar que la categoría existe si se especifica
            if (updateBookDto.CategoryId.HasValue)
            {
                var categoryExists = await _categoryRepository.ExistsAsync(updateBookDto.CategoryId.Value);
                if (!categoryExists)
                    throw new ArgumentException("La categoría especificada no existe.");
            }

            // Validar que todos los autores existen si se especifican
            if (updateBookDto.AuthorIds != null && updateBookDto.AuthorIds.Any())
            {
                foreach (var authorId in updateBookDto.AuthorIds)
                {
                    var authorExists = await _authorRepository.ExistsAsync(authorId);
                    if (!authorExists)
                        throw new ArgumentException($"El autor con ID {authorId} no existe.");
                }
            }

            // Actualizar la entidad con los datos del DTO
            BookMapper.UpdateEntity(existingBook, updateBookDto);

            // Actualizar autores si se especifican
            if (updateBookDto.AuthorIds != null)
            {
                existingBook.Authors.Clear();
                foreach (var authorId in updateBookDto.AuthorIds)
                {
                    var author = await _authorRepository.GetByIdAsync(authorId);
                    if (author != null)
                    {
                        existingBook.Authors.Add(author);
                    }
                }
            }

            // Guardar cambios
            var updatedBook = await _bookRepository.UpdateAsync(existingBook);

            // Obtener el libro completo con relaciones
            var bookWithRelations = await _bookRepository.GetBookWithAuthorsAsync(updatedBook.Id);
            return BookMapper.ToResponseDto(bookWithRelations!);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new ArgumentException("Book not found.");

            await _bookRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksByAuthorAsync(int authorId)
        {
            var books = await _bookRepository.GetBooksByAuthorAsync(authorId);
            return BookMapper.ToResponseDtoList(books);
        }

        public async Task<IEnumerable<BookResponseDto>> GetBooksByRatingAsync(decimal minRating)
        {
            var books = await _bookRepository.GetBooksByRatingAsync((int)minRating);
            return BookMapper.ToResponseDtoList(books);
        }

        public async Task<IEnumerable<BookResponseDto>> SearchBooksByTitleAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Search title cannot be empty.");

            var books = await _bookRepository.SearchBooksByTitleAsync(title);
            return BookMapper.ToResponseDtoList(books);
        }

        public async Task<BookResponseDto?> GetBookWithAuthorsAsync(int bookId)
        {
            var book = await _bookRepository.GetBookWithAuthorsAsync(bookId);
            return book != null ? BookMapper.ToResponseDto(book) : null;
        }

        public async Task<IEnumerable<BookResponseDto>> SearchBooksAsync(BookSearchDto searchDto)
        {
            var books = await _bookRepository.GetAllAsync();
            var query = books.AsQueryable();

            // Filtrar por título
            if (!string.IsNullOrWhiteSpace(searchDto.Title))
            {
                query = query.Where(b => b.Title.Contains(searchDto.Title, StringComparison.OrdinalIgnoreCase));
            }

            // Filtrar por autor
            if (!string.IsNullOrWhiteSpace(searchDto.Author))
            {
                query = query.Where(b => b.Authors.Any(a => a.Name.Contains(searchDto.Author, StringComparison.OrdinalIgnoreCase)));
            }

            // Filtrar por género
            if (!string.IsNullOrWhiteSpace(searchDto.Genre))
            {
                query = query.Where(b => !string.IsNullOrEmpty(b.Genre) && b.Genre.Contains(searchDto.Genre, StringComparison.OrdinalIgnoreCase));
            }

            // Filtrar por categoría
            if (searchDto.CategoryId.HasValue)
            {
                query = query.Where(b => b.CategoryId == searchDto.CategoryId.Value);
            }

            // Filtrar por rango de calificación
            if (searchDto.MinRating.HasValue)
            {
                query = query.Where(b => b.Rating >= searchDto.MinRating.Value);
            }

            if (searchDto.MaxRating.HasValue)
            {
                query = query.Where(b => b.Rating <= searchDto.MaxRating.Value);
            }

            // Filtrar por rango de precio
            if (searchDto.MinPrice.HasValue)
            {
                query = query.Where(b => b.Price >= searchDto.MinPrice.Value);
            }

            if (searchDto.MaxPrice.HasValue)
            {
                query = query.Where(b => b.Price <= searchDto.MaxPrice.Value);
            }

            // Filtrar por disponibilidad
            if (searchDto.IsAvailable.HasValue)
            {
                query = query.Where(b => b.IsAvailable == searchDto.IsAvailable.Value);
            }

            // Filtrar por stock mínimo
            if (searchDto.MinStock.HasValue)
            {
                query = query.Where(b => b.Stock >= searchDto.MinStock.Value);
            }

            // Filtrar por rango de fechas de publicación
            if (searchDto.PublicationDateFrom.HasValue)
            {
                query = query.Where(b => b.PublicationDate >= searchDto.PublicationDateFrom.Value);
            }

            if (searchDto.PublicationDateTo.HasValue)
            {
                query = query.Where(b => b.PublicationDate <= searchDto.PublicationDateTo.Value);
            }

            // Aplicar ordenamiento
            if (!string.IsNullOrEmpty(searchDto.SortBy))
            {
                bool isDescending = searchDto.SortDirection?.ToLower() == "desc";
                
                switch (searchDto.SortBy.ToLower())
                {
                    case "title":
                        query = isDescending ? query.OrderByDescending(b => b.Title) : query.OrderBy(b => b.Title);
                        break;
                    case "rating":
                        query = isDescending ? query.OrderByDescending(b => b.Rating) : query.OrderBy(b => b.Rating);
                        break;
                    case "price":
                        query = isDescending ? query.OrderByDescending(b => b.Price) : query.OrderBy(b => b.Price);
                        break;
                    case "publicationdate":
                        query = isDescending ? query.OrderByDescending(b => b.PublicationDate) : query.OrderBy(b => b.PublicationDate);
                        break;
                    default:
                        query = query.OrderBy(b => b.Title);
                        break;
                }
            }
            else
            {
                query = query.OrderBy(b => b.Title);
            }

            // Paginación
            if (searchDto.PageNumber > 0 && searchDto.PageSize > 0)
            {
                query = query.Skip((searchDto.PageNumber - 1) * searchDto.PageSize).Take(searchDto.PageSize);
            }

            return BookMapper.ToResponseDtoList(query.ToList());
        }

        public async Task<bool> BookExistsAsync(int id)
        {
            return await _bookRepository.ExistsAsync(id);
        }
    }
}
