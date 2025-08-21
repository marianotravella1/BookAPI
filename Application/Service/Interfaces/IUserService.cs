using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IUserService
    {
        // Métodos que retornan DTOs
        Task<UserResponseDto?> GetUserByIdAsync(int id);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserByUsernameAsync(string username);
        Task<UserResponseDto?> GetUserByEmailAsync(string email);
        
        // Métodos que aceptan DTOs
        Task<UserResponseDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserResponseDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        
        // Métodos de utilidad
        Task DeleteUserAsync(int id);
        Task<bool> IsUsernameAvailableAsync(string username);
        Task<bool> IsEmailAvailableAsync(string email);
        Task<bool> UserExistsAsync(int id);
    }
}
