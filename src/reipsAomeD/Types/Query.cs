namespace reipsAomeD.Types;

[QueryType]
public class Query
{
    public IQueryable<Book> GetBooks(LibraryService libraryService)
        => libraryService.GetBooks().Select(b => new Book(b.BookId, b.AuthorId, b.Amount));
}
