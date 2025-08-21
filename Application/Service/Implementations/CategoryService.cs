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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category != null ? CategoryMapper.ToResponseDto(category) : null;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return CategoryMapper.ToResponseDtos(categories);
        }

        public async Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(createCategoryDto.Name))
                throw new ArgumentException("Category name is required.");

            // Verificar que no existe una categoría con el mismo nombre
            var existingCategory = await _categoryRepository.CategoryExistsByNameAsync(createCategoryDto.Name);
            if (existingCategory)
                throw new ArgumentException("A category with this name already exists.");

            var category = CategoryMapper.ToEntity(createCategoryDto);
            var createdCategory = await _categoryRepository.AddAsync(category);
            return CategoryMapper.ToResponseDto(createdCategory);
        }

        public async Task<CategoryResponseDto> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto)
        {
            // Verificar que la categoría existe
            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
                throw new ArgumentException("Category not found.");

            // Verificar que no existe otra categoría con el mismo nombre (si se está cambiando el nombre)
            if (!string.IsNullOrWhiteSpace(updateCategoryDto.Name) && updateCategoryDto.Name != existingCategory.Name)
            {
                var categoryWithSameName = await _categoryRepository.GetCategoryByNameAsync(updateCategoryDto.Name);
                if (categoryWithSameName != null && categoryWithSameName.Id != id)
                    throw new ArgumentException("A category with this name already exists.");
            }

            CategoryMapper.UpdateEntity(existingCategory, updateCategoryDto);
            var updatedCategory = await _categoryRepository.UpdateAsync(existingCategory);
            return CategoryMapper.ToResponseDto(updatedCategory);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new ArgumentException("Category not found.");

            // Verificar si la categoría tiene libros asociados
            var categoryWithBooks = await _categoryRepository.GetCategoryWithBooksAsync(id);
            if (categoryWithBooks?.Books.Any() == true)
                throw new InvalidOperationException("Cannot delete category that has books associated with it.");

            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryResponseDto?> GetCategoryByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Category name cannot be empty.");

            var category = await _categoryRepository.GetCategoryByNameAsync(name);
            return category != null ? CategoryMapper.ToResponseDto(category) : null;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetCategoriesWithBooksAsync()
        {
            var categories = await _categoryRepository.GetCategoriesWithBooksAsync();
            return CategoryMapper.ToResponseDtos(categories);
        }

        public async Task<CategoryResponseDto?> GetCategoryWithBooksAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryWithBooksAsync(categoryId);
            return category != null ? CategoryMapper.ToResponseDto(category) : null;
        }

        public async Task<bool> CategoryExistsAsync(int id)
        {
            return await _categoryRepository.ExistsAsync(id);
        }

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return await _categoryRepository.CategoryExistsByNameAsync(name);
        }
    }
}