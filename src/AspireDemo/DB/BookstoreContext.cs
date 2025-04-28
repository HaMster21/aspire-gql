using Microsoft.EntityFrameworkCore;

namespace AspireDemo
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired().HasMaxLength(255);
                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(255);
            });
        }
    }
}