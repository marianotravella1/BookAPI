using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto?> GetCategoryByIdAsync(int id);
        Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();
        Task<CategoryResponseDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryResponseDto> UpdateCategoryAsync(int id, UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<CategoryResponseDto?> GetCategoryByNameAsync(string name);
        Task<IEnumerable<CategoryResponseDto>> GetCategoriesWithBooksAsync();
        Task<CategoryResponseDto?> GetCategoryWithBooksAsync(int categoryId);
        Task<bool> CategoryExistsAsync(int id);
        Task<bool> CategoryExistsByNameAsync(string name);
    }
}