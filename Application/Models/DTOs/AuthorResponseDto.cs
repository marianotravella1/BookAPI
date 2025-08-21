using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// DTO para la respuesta básica de autor (versión resumida)
    /// </summary>
    public class AuthorResponseDto
    {
        /// <summary>
        /// ID único del autor
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo del autor
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Biografía del autor
        /// </summary>
        public string? Biography { get; set; }

        /// <summary>
        /// Fecha de nacimiento del autor
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Fecha de fallecimiento del autor (si aplica)
        /// </summary>
        public DateTime? DeathDate { get; set; }

        /// <summary>
        /// Nacionalidad del autor
        /// </summary>
        public string? Nationality { get; set; }

        /// <summary>
        /// URL de la foto del autor
        /// </summary>
        public string? PhotoURL { get; set; }
    }
}