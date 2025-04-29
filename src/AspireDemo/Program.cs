using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var connectionString = builder.Configuration.GetConnectionString("BookstoreDb");
builder.Services.AddDbContextFactory<BookstoreContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlServer(connectionString, options =>
{
    options.EnableRetryOnFailure(5);
}));
builder.EnrichSqlServerDbContext<BookstoreContext>();

builder.Services.AddScoped<BookService>();

builder.AddGraphQL().AddTypes();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    // Migration des einfachen Mannes, wenn nur eine Instanz eines Services die Datenbank unter Kontrolle hat
    using var scope = app.Services.CreateScope();
    using var context = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BookstoreContext>>().CreateDbContext();
    context.Database.Migrate();
}

app.RunWithGraphQLCommands(args);
