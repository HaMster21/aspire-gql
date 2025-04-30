using Microsoft.EntityFrameworkCore;

namespace reipsAomeD.Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Inventory> Books { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguration der Beziehungen und Einschränkungen
            modelBuilder.Entity<Inventory>()
                .HasKey(b => b.Id);
        }
    }
}
