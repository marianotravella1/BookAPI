using Application.Models.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Mappers
{
    /// <summary>
    /// Mapper para conversiones entre User entity y DTOs
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Convierte una entidad User a UserResponseDto
        /// </summary>
        /// <param name="user">Entidad User</param>
        /// <returns>UserResponseDto</returns>
        public static UserResponseDto ToResponseDto(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }

        /// <summary>
        /// Convierte una colección de entidades User a una lista de UserResponseDto
        /// </summary>
        /// <param name="users">Colección de entidades User</param>
        /// <returns>Lista de UserResponseDto</returns>
        public static IEnumerable<UserResponseDto> ToResponseDtos(IEnumerable<User> users)
        {
            if (users == null)
                throw new ArgumentNullException(nameof(users));

            return users.Select(ToResponseDto);
        }

        /// <summary>
        /// Convierte un CreateUserDto a una entidad User
        /// </summary>
        /// <param name="createUserDto">DTO para crear usuario</param>
        /// <returns>Entidad User</returns>
        public static User ToEntity(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
                throw new ArgumentNullException(nameof(createUserDto));

            return new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                PasswordHash = createUserDto.Password // En un escenario real, esto debería ser hasheado
            };
        }

        /// <summary>
        /// Actualiza una entidad User existente con datos de UpdateUserDto
        /// </summary>
        /// <param name="user">Entidad User existente</param>
        /// <param name="updateUserDto">DTO con datos de actualización</param>
        public static void UpdateEntity(User user, UpdateUserDto updateUserDto)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (updateUserDto == null)
                throw new ArgumentNullException(nameof(updateUserDto));

            if (!string.IsNullOrWhiteSpace(updateUserDto.Username))
                user.Username = updateUserDto.Username;

            if (!string.IsNullOrWhiteSpace(updateUserDto.Email))
                user.Email = updateUserDto.Email;

            if (!string.IsNullOrWhiteSpace(updateUserDto.Password))
                user.PasswordHash = updateUserDto.Password; // En un escenario real, esto debería ser hasheado
        }
    }
}