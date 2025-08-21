namespace Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for user response data
    /// </summary>
    public class UserResponseDto
    {
        /// <summary>
        /// Unique identifier for the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username of the user
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Email address of the user
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}