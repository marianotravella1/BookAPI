using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// DTO para la creación de un nuevo autor
    /// </summary>
    public class CreateAuthorDto
    {
        /// <summary>
        /// Nombre completo del autor
        /// </summary>
        [Required(ErrorMessage = "El nombre del autor es requerido")]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 200 caracteres")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Biografía del autor
        /// </summary>
        [StringLength(2000, ErrorMessage = "La biografía no puede exceder los 2000 caracteres")]
        public string? Biography { get; set; }

        /// <summary>
        /// Fecha de nacimiento del autor
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Fecha de fallecimiento del autor (si aplica)
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? DeathDate { get; set; }

        /// <summary>
        /// Nacionalidad del autor
        /// </summary>
        [StringLength(100, ErrorMessage = "La nacionalidad no puede exceder los 100 caracteres")]
        public string? Nationality { get; set; }

        /// <summary>
        /// URL de la foto del autor
        /// </summary>
        [Url(ErrorMessage = "Debe ser una URL válida")]
        [StringLength(500, ErrorMessage = "La URL no puede exceder los 500 caracteres")]
        public string? PhotoURL { get; set; }
    }
}