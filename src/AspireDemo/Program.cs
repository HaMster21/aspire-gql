using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddDbContextFactory<BookstoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookstoreDb"));
});
builder.Services.AddScoped<BookService>();

builder.AddGraphQL().AddTypes();

var app = builder.Build();

app.MapDefaultEndpoints();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
