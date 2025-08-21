using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object para la creación de una nueva categoría.
    /// Contiene los campos requeridos y validaciones necesarias para crear una categoría.
    /// </summary>
    public class CreateCategoryDto
    {
        /// <summary>
        /// Nombre de la categoría.
        /// Campo requerido con longitud máxima de 100 caracteres.
        /// </summary>
        /// <example>Ficción</example>
        [Required(ErrorMessage = "El nombre de la categoría es requerido.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción opcional de la categoría.
        /// Campo opcional con longitud máxima de 500 caracteres.
        /// </summary>
        /// <example>Libros de ficción literaria y narrativa</example>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Description { get; set; }
    }
}