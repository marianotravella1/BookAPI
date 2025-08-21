using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// DTO para búsqueda y filtrado de libros
    /// </summary>
    public class BookSearchDto
    {
        /// <summary>
        /// Término de búsqueda general (busca en título, autor, género, etc.)
        /// </summary>
        [StringLength(200, ErrorMessage = "El término de búsqueda no puede exceder los 200 caracteres")]
        public string? SearchTerm { get; set; }

        /// <summary>
        /// Filtro por título específico
        /// </summary>
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        public string? Title { get; set; }

        /// <summary>
        /// Filtro por autor específico
        /// </summary>
        [StringLength(200, ErrorMessage = "El nombre del autor no puede exceder los 200 caracteres")]
        public string? Author { get; set; }

        /// <summary>
        /// Filtro por género
        /// </summary>
        [StringLength(100, ErrorMessage = "El género no puede exceder los 100 caracteres")]
        public string? Genre { get; set; }

        /// <summary>
        /// Filtro por editorial
        /// </summary>
        [StringLength(200, ErrorMessage = "La editorial no puede exceder los 200 caracteres")]
        public string? Publisher { get; set; }

        /// <summary>
        /// Filtro por idioma
        /// </summary>
        [StringLength(50, ErrorMessage = "El idioma no puede exceder los 50 caracteres")]
        public string? Language { get; set; }

        /// <summary>
        /// Filtro por ISBN
        /// </summary>
        [StringLength(20, ErrorMessage = "El ISBN no puede exceder los 20 caracteres")]
        public string? ISBN { get; set; }

        /// <summary>
        /// Filtro por categoría ID
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "El ID de categoría debe ser mayor a 0")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Filtro por calificación mínima
        /// </summary>
        [Range(1, 5, ErrorMessage = "La calificación mínima debe estar entre 1 y 5")]
        public int? MinRating { get; set; }

        /// <summary>
        /// Filtro por calificación máxima
        /// </summary>
        [Range(1, 5, ErrorMessage = "La calificación máxima debe estar entre 1 y 5")]
        public int? MaxRating { get; set; }

        /// <summary>
        /// Filtro por precio mínimo
        /// </summary>
        [Range(0, 999999.99, ErrorMessage = "El precio mínimo debe ser mayor o igual a 0")]
        public decimal? MinPrice { get; set; }

        /// <summary>
        /// Filtro por precio máximo
        /// </summary>
        [Range(0.01, 999999.99, ErrorMessage = "El precio máximo debe ser mayor a 0")]
        public decimal? MaxPrice { get; set; }

        /// <summary>
        /// Filtro por fecha de publicación desde
        /// </summary>
        public DateTime? PublicationDateFrom { get; set; }

        /// <summary>
        /// Filtro por fecha de publicación hasta
        /// </summary>
        public DateTime? PublicationDateTo { get; set; }

        /// <summary>
        /// Filtro por disponibilidad
        /// </summary>
        public bool? IsAvailable { get; set; }

        /// <summary>
        /// Filtro por stock mínimo
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "El stock mínimo no puede ser negativo")]
        public int? MinStock { get; set; }

        /// <summary>
        /// Campo por el cual ordenar los resultados
        /// </summary>
        [StringLength(50, ErrorMessage = "El campo de ordenamiento no puede exceder los 50 caracteres")]
        public string? SortBy { get; set; } = "Title";

        /// <summary>
        /// Dirección del ordenamiento (asc/desc)
        /// </summary>
        [RegularExpression("^(asc|desc)$", ErrorMessage = "La dirección de ordenamiento debe ser 'asc' o 'desc'")]
        public string? SortDirection { get; set; } = "asc";

        /// <summary>
        /// Número de página para paginación
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "El número de página debe ser mayor a 0")]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Tamaño de página para paginación
        /// </summary>
        [Range(1, 100, ErrorMessage = "El tamaño de página debe estar entre 1 y 100")]
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Validación personalizada para rangos de precios
        /// </summary>
        public bool IsValidPriceRange()
        {
            if (MinPrice.HasValue && MaxPrice.HasValue)
            {
                return MinPrice.Value <= MaxPrice.Value;
            }
            return true;
        }

        /// <summary>
        /// Validación personalizada para rangos de calificación
        /// </summary>
        public bool IsValidRatingRange()
        {
            if (MinRating.HasValue && MaxRating.HasValue)
            {
                return MinRating.Value <= MaxRating.Value;
            }
            return true;
        }

        /// <summary>
        /// Validación personalizada para rangos de fechas
        /// </summary>
        public bool IsValidDateRange()
        {
            if (PublicationDateFrom.HasValue && PublicationDateTo.HasValue)
            {
                return PublicationDateFrom.Value <= PublicationDateTo.Value;
            }
            return true;
        }
    }
}