using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for updating an existing user
    /// </summary>
    public class UpdateUserDto
    {
        /// <summary>
        /// Updated username for the user (optional)
        /// </summary>
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can only contain letters, numbers, and underscores")]
        public string? Username { get; set; }

        /// <summary>
        /// Updated email address for the user (optional)
        /// </summary>
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? Email { get; set; }

        /// <summary>
        /// New password for the user (optional)
        /// </summary>
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 100 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character")]
        public string? Password { get; set; }

        /// <summary>
        /// Password confirmation for validation (required only if Password is provided)
        /// </summary>
        [Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
        public string? ConfirmPassword { get; set; }
    }
}