namespace AspireDemo.Types;

[QueryType]
public class Query
{
    public IQueryable<Book> GetBooks(BookService bookService)
        => bookService
            .GetBooks()
            .Select(b => new Book(b.Title, new Author(b.Author.Name)));
}
