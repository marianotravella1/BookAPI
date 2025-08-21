using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object para la actualización de una categoría existente.
    /// Todos los campos son opcionales, pero mantienen las mismas validaciones cuando están presentes.
    /// </summary>
    public class UpdateCategoryDto
    {
        /// <summary>
        /// Nombre de la categoría.
        /// Campo opcional con longitud máxima de 100 caracteres cuando está presente.
        /// </summary>
        /// <example>Ficción Contemporánea</example>
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe tener entre 1 y 100 caracteres.")]
        public string? Name { get; set; }

        /// <summary>
        /// Descripción de la categoría.
        /// Campo opcional con longitud máxima de 500 caracteres cuando está presente.
        /// </summary>
        /// <example>Libros de ficción contemporánea y narrativa moderna</example>
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string? Description { get; set; }
    }
}