
using Microsoft.EntityFrameworkCore;

namespace AspireDemo;

public sealed class BookService : IAsyncDisposable
{
    private readonly BookstoreContext _dbContext;

    public BookService(IDbContextFactory<BookstoreContext> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public ValueTask DisposeAsync()
    {
        return _dbContext.DisposeAsync();
    }

    public IQueryable<Book> GetBooks()
    {
        return _dbContext.Books
            .Include(b => b.Author)
            .AsQueryable();
    }
}