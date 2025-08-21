namespace Application.Models.DTOs
{
    /// <summary>
    /// DTO para la respuesta al consultar libros
    /// </summary>
    public class BookResponseDto
    {
        /// <summary>
        /// ID único del libro
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título del libro
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Resumen o descripción del libro
        /// </summary>
        public string? Summary { get; set; }

        /// <summary>
        /// Calificación del libro (1-5)
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Cantidad de páginas del libro
        /// </summary>
        public int PagesAmount { get; set; }

        /// <summary>
        /// URL de la imagen del libro
        /// </summary>
        public string? ImageURL { get; set; }

        /// <summary>
        /// Precio del libro
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Cantidad en stock
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Código ISBN del libro
        /// </summary>
        public string? ISBN { get; set; }

        /// <summary>
        /// Fecha de publicación del libro
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// Editorial del libro
        /// </summary>
        public string? Publisher { get; set; }

        /// <summary>
        /// Idioma del libro
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Género del libro
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// Indica si el libro está disponible
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Fecha de creación del registro
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Fecha de última actualización
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// ID de la categoría del libro
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Información de la categoría del libro
        /// </summary>
        public CategoryResponseDto? Category { get; set; }

        /// <summary>
        /// Lista de autores del libro
        /// </summary>
        public List<AuthorDetailResponseDto> Authors { get; set; } = new List<AuthorDetailResponseDto>();
    }


}