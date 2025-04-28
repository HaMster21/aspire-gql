
using Microsoft.EntityFrameworkCore;

namespace AspireDemo.Types;

[QueryType]
public class Query(BookService bookService)
{
    public IQueryable<Book> GetBooks() => bookService.GetBooks().Select(b => new Book(b.Title, new Author(b.Author.Name)));
}
