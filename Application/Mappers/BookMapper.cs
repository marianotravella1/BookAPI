using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    /// <summary>
    /// Mapper para convertir entre entidades Book y DTOs
    /// </summary>
    public static class BookMapper
    {
        /// <summary>
        /// Convierte una entidad Book a BookResponseDto
        /// </summary>
        /// <param name="book">Entidad Book</param>
        /// <returns>BookResponseDto</returns>
        public static BookResponseDto ToResponseDto(Book book)
        {
            return new BookResponseDto
            {
                Id = book.Id,
                Title = book.Title,
                Summary = book.Summary,
                Price = book.Price,
                Stock = book.Stock,
                IsAvailable = book.IsAvailable,
                PublicationDate = book.PublicationDate,
                Genre = book.Genre,
                Rating = book.Rating,
                ISBN = book.ISBN,
                Publisher = book.Publisher,
                Language = book.Language,
                PagesAmount = book.PagesAmount,
                ImageURL = book.ImageURL,
                CreatedAt = book.CreatedAt,
                UpdatedAt = book.UpdatedAt,
                CategoryId = book.CategoryId,
                Category = book.Category != null ? new CategoryResponseDto
                {
                    Id = book.Category.Id,
                    Name = book.Category.Name,
                    Description = book.Category.Description
                } : null,
                Authors = book.Authors?.Select(a => new AuthorDetailResponseDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Biography = a.Biography,
                    BirthDate = a.BirthDate,
                    DeathDate = a.DeathDate,
                    Nationality = a.Nationality,
                    PhotoURL = a.PhotoURL,
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt,
                    Books = new List<BookResponseDto>() // Evitar referencia circular
                }).ToList() ?? new List<AuthorDetailResponseDto>()
            };
        }

        /// <summary>
        /// Convierte un CreateBookDto a entidad Book
        /// </summary>
        /// <param name="createDto">DTO de creación</param>
        /// <returns>Entidad Book</returns>
        public static Book ToEntity(CreateBookDto createDto)
        {
            if (createDto == null) throw new ArgumentNullException(nameof(createDto));

            return new Book
            {
                Title = createDto.Title,
                Summary = createDto.Summary,
                Rating = createDto.Rating,
                PagesAmount = createDto.PagesAmount,
                ImageURL = createDto.ImageURL,
                Price = createDto.Price,
                Stock = createDto.Stock,
                ISBN = createDto.ISBN,
                PublicationDate = createDto.PublicationDate,
                Publisher = createDto.Publisher,
                Language = createDto.Language ?? "Español",
                Genre = createDto.Genre,
                IsAvailable = createDto.IsAvailable,
                CategoryId = createDto.CategoryId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Actualiza una entidad Book existente con datos de UpdateBookDto
        /// </summary>
        /// <param name="book">Entidad Book existente</param>
        /// <param name="updateDto">DTO de actualización</param>
        public static void UpdateEntity(Book book, UpdateBookDto updateDto)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (updateDto == null) throw new ArgumentNullException(nameof(updateDto));

            if (!string.IsNullOrWhiteSpace(updateDto.Title))
                book.Title = updateDto.Title;

            if (updateDto.Summary != null)
                book.Summary = updateDto.Summary;

            if (updateDto.Rating.HasValue)
                book.Rating = updateDto.Rating.Value;

            if (updateDto.PagesAmount.HasValue)
                book.PagesAmount = updateDto.PagesAmount.Value;

            if (updateDto.ImageURL != null)
                book.ImageURL = updateDto.ImageURL;

            if (updateDto.Price.HasValue)
                book.Price = updateDto.Price.Value;

            if (updateDto.Stock.HasValue)
                book.Stock = updateDto.Stock.Value;

            if (updateDto.ISBN != null)
                book.ISBN = updateDto.ISBN;

            if (updateDto.PublicationDate.HasValue)
                book.PublicationDate = updateDto.PublicationDate;

            if (!string.IsNullOrWhiteSpace(updateDto.Publisher))
                book.Publisher = updateDto.Publisher;

            if (!string.IsNullOrWhiteSpace(updateDto.Language))
                book.Language = updateDto.Language;

            if (!string.IsNullOrWhiteSpace(updateDto.Genre))
                book.Genre = updateDto.Genre;

            if (updateDto.IsAvailable.HasValue)
                book.IsAvailable = updateDto.IsAvailable.Value;

            if (updateDto.CategoryId.HasValue)
                book.CategoryId = updateDto.CategoryId;

            book.UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Convierte una lista de entidades Book a lista de BookResponseDto
        /// </summary>
        /// <param name="books">Lista de entidades Book</param>
        /// <returns>Lista de BookResponseDto</returns>
        public static IEnumerable<BookResponseDto> ToResponseDtoList(IEnumerable<Book> books)
        {
            return books?.Select(ToResponseDto) ?? new List<BookResponseDto>();
        }
    }
}