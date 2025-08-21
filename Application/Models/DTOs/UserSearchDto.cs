namespace Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object for user search and filtering parameters
    /// </summary>
    public class UserSearchDto
    {
        /// <summary>
        /// Search term to filter users by username or email
        /// </summary>
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Filter by specific username
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Filter by specific email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Page number for pagination (default: 1)
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Number of items per page (default: 10, max: 100)
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Field to sort by (Id, Username, Email)
        /// </summary>
        public string? SortBy { get; set; }

        /// <summary>
        /// Sort direction (asc or desc)
        /// </summary>
        public string? SortDirection { get; set; } = "asc";
    }
}