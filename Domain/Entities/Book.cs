using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Summary { get; set; }
        public int Rating { get; set; }
        public int PagesAmount { get; set; }
        [Url]
        public string? ImageURL { get; set; }
        
        // Campos para librería online
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ISBN { get; set; }
        public DateTime? PublicationDate { get; set; }
        public string? Publisher { get; set; }
        public string? Language { get; set; } = "Español";
        public string? Genre { get; set; }
        public bool IsAvailable { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
        public List<Author> Authors { get; set; } = new List<Author>();
    }
}
