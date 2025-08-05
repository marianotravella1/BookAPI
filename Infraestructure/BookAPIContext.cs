using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class BookAPIContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public BookAPIContext(DbContextOptions<BookAPIContext> options) : base(options) 
        { 
        }
    }
}
