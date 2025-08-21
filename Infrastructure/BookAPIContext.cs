using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BookAPIContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public BookAPIContext(DbContextOptions<BookAPIContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Book-Author many-to-many relationship
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity("BookAuthor");

            // Configure Book-Category one-to-many relationship
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configure Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(b => b.Summary)
                    .HasMaxLength(1000);
                entity.Property(b => b.Rating)
                    .IsRequired();
                entity.Property(b => b.PagesAmount)
                    .IsRequired();
                entity.Property(b => b.ImageURL)
                    .HasMaxLength(500);
                entity.Property(b => b.Price)
                    .HasColumnType("decimal(10,2)")
                    .IsRequired();
                entity.Property(b => b.Stock)
                    .IsRequired();
                entity.Property(b => b.ISBN)
                    .HasMaxLength(20);
                entity.Property(b => b.Publisher)
                    .HasMaxLength(200);
                entity.Property(b => b.Language)
                    .HasMaxLength(50)
                    .HasDefaultValue("Español");
                entity.Property(b => b.Genre)
                    .HasMaxLength(100);
                entity.Property(b => b.IsAvailable)
                    .HasDefaultValue(true);
                entity.Property(b => b.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
                entity.Property(b => b.CategoryId)
                    .IsRequired(false);
            });

            // Configure Author entity
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(a => a.Biography)
                    .HasMaxLength(2000);
                entity.Property(a => a.Nationality)
                    .HasMaxLength(100);
                entity.Property(a => a.PhotoURL)
                    .HasMaxLength(500);
                entity.Property(a => a.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
            });

            // Configure Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(c => c.Description)
                    .HasMaxLength(500);
                entity.Property(c => c.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
                entity.HasIndex(c => c.Name)
                    .IsUnique();
            });

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.HasIndex(u => u.Username)
                    .IsUnique();
                entity.HasIndex(u => u.Email)
                    .IsUnique();
            });

            // No seeding data - clean database
        }
    }
}
