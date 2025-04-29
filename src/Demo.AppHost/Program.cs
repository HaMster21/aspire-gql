var builder = DistributedApplication.CreateBuilder(args);

var dbService = builder
    .AddSqlServer("sql");

var bookstoreDb = dbService
    .AddDatabase("BookstoreDb");

var api = builder
    .AddProject<Projects.AspireDemo>("aspiredemo")
    .WithReference(bookstoreDb);

builder.Build().Run();
