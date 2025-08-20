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

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username is required.");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email is required.");

            if (!await _userRepository.IsUsernameAvailableAsync(user.Username))
                throw new ArgumentException("Username is already taken.");

            if (!await _userRepository.IsEmailAvailableAsync(user.Email))
                throw new ArgumentException("Email is already registered.");

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser == null)
                throw new ArgumentException("User not found.");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username is required.");

            if (string.IsNullOrWhiteSpace(user.Email))
                throw new ArgumentException("Email is required.");

            // Check if username is taken by another user
            var userWithSameUsername = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (userWithSameUsername != null && userWithSameUsername.Id != user.Id)
                throw new ArgumentException("Username is already taken.");

            // Check if email is taken by another user
            var userWithSameEmail = await _userRepository.GetUserByEmailAsync(user.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != user.Id)
                throw new ArgumentException("Email is already registered.");

            return await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new ArgumentException("User not found.");

            await _userRepository.DeleteAsync(id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be empty.");

            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty.");

            return await _userRepository.GetUserByEmailAsync(email);
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
