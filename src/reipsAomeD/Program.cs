using Microsoft.EntityFrameworkCore;

using reipsAomeD.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LibraryDb") ?? "";
builder.Services.AddDbContextFactory<LibraryContext>(dbContextOptionsBuilder =>
    dbContextOptionsBuilder.UseSqlServer(connectionString, options =>
    {
        options.EnableRetryOnFailure(5);
    }).UseSeeding((context, _) =>
    {
        var book = context
            .Set<Inventory>()
            .Where(book => book.AuthorId == 1)
            .Where(book => book.BookId == 1)
            .FirstOrDefault();

        if (book == null)
        {
            context.Set<Inventory>().Add(new Inventory()
            {
                BookId = 1,
                AuthorId = 1,
                Amount = 42
            });
            context.SaveChanges();
        }
    }));
builder.EnrichSqlServerDbContext<LibraryContext>();

builder.Services.AddScoped<LibraryService>();

builder.AddGraphQL().AddTypes();

var app = builder.Build();

app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    // Migration des einfachen Mannes, wenn nur eine Instanz eines Services die Datenbank unter Kontrolle hat
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<IDbContextFactory<LibraryContext>>().CreateDbContext();
    context.Database.Migrate();
}

app.RunWithGraphQLCommands(args);
