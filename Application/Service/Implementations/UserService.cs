using Application.Models.DTOs;
using Application.Mappers;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? UserMapper.ToResponseDto(user) : null;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return UserMapper.ToResponseDtos(users);
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.Username))
                throw new ArgumentException("Username is required.");

            if (string.IsNullOrWhiteSpace(createUserDto.Email))
                throw new ArgumentException("Email is required.");

            if (!await _userRepository.IsUsernameAvailableAsync(createUserDto.Username))
                throw new ArgumentException("Username is already taken.");

            if (!await _userRepository.IsEmailAvailableAsync(createUserDto.Email))
                throw new ArgumentException("Email is already registered.");

            var user = UserMapper.ToEntity(createUserDto);
            var createdUser = await _userRepository.AddAsync(user);
            return UserMapper.ToResponseDto(createdUser);
        }

        public async Task<UserResponseDto> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
                throw new ArgumentException("User not found.");

            // Check if username is taken by another user
            if (!string.IsNullOrWhiteSpace(updateUserDto.Username))
            {
                var userWithSameUsername = await _userRepository.GetUserByUsernameAsync(updateUserDto.Username);
                if (userWithSameUsername != null && userWithSameUsername.Id != id)
                    throw new ArgumentException("Username is already taken.");
            }

            // Check if email is taken by another user
            if (!string.IsNullOrWhiteSpace(updateUserDto.Email))
            {
                var userWithSameEmail = await _userRepository.GetUserByEmailAsync(updateUserDto.Email);
                if (userWithSameEmail != null && userWithSameEmail.Id != id)
                    throw new ArgumentException("Email is already registered.");
            }

            UserMapper.UpdateEntity(existingUser, updateUserDto);
            var updatedUser = await _userRepository.UpdateAsync(existingUser);
            return UserMapper.ToResponseDto(updatedUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User not found.");

            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserResponseDto?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            var user = await _userRepository.GetUserByUsernameAsync(username);
            return user != null ? UserMapper.ToResponseDto(user) : null;
        }

        public async Task<UserResponseDto?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            var user = await _userRepository.GetUserByEmailAsync(email);
            return user != null ? UserMapper.ToResponseDto(user) : null;
        }

        public async Task<bool> IsUsernameAvailableAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return false;

            return await _userRepository.IsUsernameAvailableAsync(username);
        }

        public async Task<bool> IsEmailAvailableAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return await _userRepository.IsEmailAvailableAsync(email);
        }

        public async Task<bool> UserExistsAsync(int id)
        {
            return await _userRepository.ExistsAsync(id);
        }
    }
}
