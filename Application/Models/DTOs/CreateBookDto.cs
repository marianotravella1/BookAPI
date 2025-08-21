using System.ComponentModel.DataAnnotations;

namespace Application.Models.DTOs
{
    /// <summary>
    /// DTO para la creación de nuevos libros
    /// </summary>
    public class CreateBookDto
    {
        /// <summary>
        /// Título del libro (obligatorio)
        /// </summary>
        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(200, ErrorMessage = "El título no puede exceder los 200 caracteres")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Resumen o descripción del libro
        /// </summary>
        [StringLength(1000, ErrorMessage = "El resumen no puede exceder los 1000 caracteres")]
        public string? Summary { get; set; }

        /// <summary>
        /// Calificación del libro (1-5)
        /// </summary>
        [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5")]
        public int Rating { get; set; }

        /// <summary>
        /// Cantidad de páginas del libro
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de páginas debe ser mayor a 0")]
        public int PagesAmount { get; set; }

        /// <summary>
        /// URL de la imagen del libro
        /// </summary>
        [Url(ErrorMessage = "Debe ser una URL válida")]
        public string? ImageURL { get; set; }

        /// <summary>
        /// Precio del libro
        /// </summary>
        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe estar entre 0.01 y 999999.99")]
        public decimal Price { get; set; }

        /// <summary>
        /// Cantidad en stock
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        /// <summary>
        /// Código ISBN del libro
        /// </summary>
        [StringLength(20, ErrorMessage = "El ISBN no puede exceder los 20 caracteres")]
        [RegularExpression(@"^(?:ISBN(?:-1[03])?:? )?(?=[0-9X]{10}$|(?=(?:[0-9]+[- ]){3})[- 0-9X]{13}$|97[89][0-9]{10}$|(?=(?:[0-9]+[- ]){4})[- 0-9]{17}$)(?:97[89][- ]?)?[0-9]{1,5}[- ]?[0-9]+[- ]?[0-9]+[- ]?[0-9X]$", 
            ErrorMessage = "El formato del ISBN no es válido")]
        public string? ISBN { get; set; }

        /// <summary>
        /// Fecha de publicación del libro
        /// </summary>
        public DateTime? PublicationDate { get; set; }

        /// <summary>
        /// Editorial del libro
        /// </summary>
        [StringLength(200, ErrorMessage = "La editorial no puede exceder los 200 caracteres")]
        public string? Publisher { get; set; }

        /// <summary>
        /// Idioma del libro
        /// </summary>
        [StringLength(50, ErrorMessage = "El idioma no puede exceder los 50 caracteres")]
        public string? Language { get; set; } = "Español";

        /// <summary>
        /// Género del libro
        /// </summary>
        [StringLength(100, ErrorMessage = "El género no puede exceder los 100 caracteres")]
        public string? Genre { get; set; }

        /// <summary>
        /// Indica si el libro está disponible
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// ID de la categoría del libro
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría válida")]
        public int? CategoryId { get; set; }

        /// <summary>
        /// Lista de IDs de autores del libro
        /// </summary>
        [Required(ErrorMessage = "Debe especificar al menos un autor")]
        [MinLength(1, ErrorMessage = "Debe especificar al menos un autor")]
        public List<int> AuthorIds { get; set; } = new List<int>();
    }
}