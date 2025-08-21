namespace Application.Models.DTOs
{
    /// <summary>
    /// Data Transfer Object para la respuesta de consulta de una categoría.
    /// Contiene todos los campos de la categoría incluyendo metadatos y relaciones.
    /// </summary>
    public class CategoryResponseDto
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        /// <example>1</example>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        /// <example>Ficción</example>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Descripción de la categoría.
        /// </summary>
        /// <example>Libros de ficción literaria y narrativa</example>
        public string? Description { get; set; }

        /// <summary>
        /// Fecha y hora de creación de la categoría.
        /// </summary>
        /// <example>2024-01-15T10:30:00Z</example>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha y hora de la última actualización de la categoría.
        /// </summary>
        /// <example>2024-01-20T14:45:00Z</example>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Número total de libros asociados a esta categoría.
        /// </summary>
        /// <example>25</example>
        public int BookCount { get; set; }

        /// <summary>
        /// Lista de libros asociados a esta categoría.
        /// Solo se incluye cuando se solicita explícitamente para evitar referencias circulares.
        /// </summary>
        public List<BookResponseDto>? Books { get; set; }
    }
}