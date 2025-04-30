using Microsoft.EntityFrameworkCore;

using reipsAomeD.Data;

namespace reipsAomeD;

public class LibraryService : IAsyncDisposable
{
    private readonly LibraryContext _context;
    public LibraryService(IDbContextFactory<LibraryContext> contextFactory)
    {
        _context = contextFactory.CreateDbContext();
    }

    public IQueryable<Inventory> GetBooks()
    {
        return _context.Books.AsQueryable();
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }
}
