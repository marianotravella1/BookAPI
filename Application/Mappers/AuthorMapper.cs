using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    /// <summary>
    /// Mapper para convertir entre entidades Author y DTOs
    /// </summary>
    public static class AuthorMapper
    {
        /// <summary>
        /// Convierte una entidad Author a AuthorDetailResponseDto
        /// </summary>
        /// <param name="author">Entidad Author</param>
        /// <returns>AuthorDetailResponseDto</returns>
        public static AuthorDetailResponseDto ToDetailResponseDto(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            return new AuthorDetailResponseDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                CreatedAt = author.CreatedAt,
                UpdatedAt = author.UpdatedAt,
                Books = author.Books?.Select(BookMapper.ToResponseDto).ToList() ?? new List<BookResponseDto>()
            };
        }

        /// <summary>
        /// Convierte una entidad Author a AuthorResponseDto (versión resumida)
        /// </summary>
        /// <param name="author">Entidad Author</param>
        /// <returns>AuthorResponseDto</returns>
        public static AuthorResponseDto ToResponseDto(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            return new AuthorResponseDto
            {
                Id = author.Id,
                Name = author.Name,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Nationality = author.Nationality,
                PhotoURL = author.PhotoURL
            };
        }

        /// <summary>
        /// Convierte un CreateAuthorDto a entidad Author
        /// </summary>
        /// <param name="createDto">DTO de creación</param>
        /// <returns>Entidad Author</returns>
        public static Author ToEntity(CreateAuthorDto createDto)
        {
            if (createDto == null)
                throw new ArgumentNullException(nameof(createDto));

            return new Author
            {
                Name = createDto.Name,
                Biography = createDto.Biography,
                BirthDate = createDto.BirthDate,
                DeathDate = createDto.DeathDate,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Actualiza una entidad Author existente con datos de UpdateAuthorDto
        /// </summary>
        /// <param name="author">Entidad Author existente</param>
        /// <param name="updateDto">DTO de actualización</param>
        public static void UpdateEntity(Author author, UpdateAuthorDto updateDto)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));
            if (updateDto == null)
                throw new ArgumentNullException(nameof(updateDto));

            if (!string.IsNullOrWhiteSpace(updateDto.Name))
                author.Name = updateDto.Name;

            if (!string.IsNullOrWhiteSpace(updateDto.Biography))
                author.Biography = updateDto.Biography;

            if (updateDto.BirthDate.HasValue)
                author.BirthDate = updateDto.BirthDate.Value;

            if (updateDto.DeathDate.HasValue)
                author.DeathDate = updateDto.DeathDate;

            author.UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Convierte una colección de entidades Author a AuthorDetailResponseDto
        /// </summary>
        /// <param name="authors">Colección de entidades Author</param>
        /// <returns>Colección de AuthorDetailResponseDto</returns>
        public static IEnumerable<AuthorDetailResponseDto> ToDetailResponseDtos(IEnumerable<Author> authors)
        {
            return authors?.Select(ToDetailResponseDto) ?? Enumerable.Empty<AuthorDetailResponseDto>();
        }

        /// <summary>
        /// Convierte una colección de entidades Author a AuthorResponseDto
        /// </summary>
        /// <param name="authors">Colección de entidades Author</param>
        /// <returns>Colección de AuthorResponseDto</returns>
        public static IEnumerable<AuthorResponseDto> ToResponseDtos(IEnumerable<Author> authors)
        {
            return authors?.Select(ToResponseDto) ?? Enumerable.Empty<AuthorResponseDto>();
        }
    }
}