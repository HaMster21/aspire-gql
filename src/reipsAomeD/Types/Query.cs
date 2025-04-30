namespace reipsAomeD.Types;

[QueryType]
public class Query
{
    public IQueryable<Inventory> GetBooks(LibraryService libraryService)
        => libraryService.GetBooks().Select(b => new Inventory(b.BookId, b.AuthorId, b.Amount));
}
