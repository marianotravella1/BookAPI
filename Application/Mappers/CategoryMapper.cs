using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    /// <summary>
    /// Mapper para conversiones entre Category entity y DTOs
    /// </summary>
    public static class CategoryMapper
    {
        /// <summary>
        /// Convierte una entidad Category a CategoryResponseDto
        /// </summary>
        /// <param name="category">La entidad Category</param>
        /// <returns>CategoryResponseDto</returns>
        public static CategoryResponseDto ToResponseDto(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
        }

        /// <summary>
        /// Convierte una colección de entidades Category a una lista de CategoryResponseDto
        /// </summary>
        /// <param name="categories">Colección de entidades Category</param>
        /// <returns>Lista de CategoryResponseDto</returns>
        public static IEnumerable<CategoryResponseDto> ToResponseDtos(IEnumerable<Category> categories)
        {
            if (categories == null)
                throw new ArgumentNullException(nameof(categories));

            return categories.Select(ToResponseDto);
        }

        /// <summary>
        /// Convierte un CreateCategoryDto a una entidad Category
        /// </summary>
        /// <param name="createCategoryDto">DTO para crear categoría</param>
        /// <returns>Entidad Category</returns>
        public static Category ToEntity(CreateCategoryDto createCategoryDto)
        {
            if (createCategoryDto == null)
                throw new ArgumentNullException(nameof(createCategoryDto));

            return new Category
            {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        /// <summary>
        /// Actualiza una entidad Category existente con datos de UpdateCategoryDto
        /// </summary>
        /// <param name="category">Entidad Category existente</param>
        /// <param name="updateCategoryDto">DTO con datos de actualización</param>
        public static void UpdateEntity(Category category, UpdateCategoryDto updateCategoryDto)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            if (updateCategoryDto == null)
                throw new ArgumentNullException(nameof(updateCategoryDto));

            if (!string.IsNullOrWhiteSpace(updateCategoryDto.Name))
                category.Name = updateCategoryDto.Name;

            if (!string.IsNullOrWhiteSpace(updateCategoryDto.Description))
                category.Description = updateCategoryDto.Description;

            category.UpdatedAt = DateTime.UtcNow;
        }
    }
}