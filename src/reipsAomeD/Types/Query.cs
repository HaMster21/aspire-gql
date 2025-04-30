namespace reipsAomeD.Types;

[QueryType]
public class Query
{
    public IQueryable<Inventory> GetInventory(LibraryService libraryService)
        => libraryService.GetBooks().Select(b => new Inventory(b.BookId, b.AuthorId, b.Amount));
}
