var builder = DistributedApplication.CreateBuilder(args);

var dbService = builder
    .AddSqlServer("sql");

var bookstoreDb = dbService
    .AddDatabase("BookstoreDb");

var libraryDb = dbService
    .AddDatabase("LibraryDb");

var books = builder
    .AddProject<Projects.AspireDemo>("aspiredemo")
    .WithReference(bookstoreDb)
    .WaitFor(bookstoreDb);

var libraries = builder
    .AddProject<Projects.reipsAomeD>("reipsaomed")
    .WithReference(libraryDb)
    .WaitFor(libraryDb);

builder.Build().Run();
