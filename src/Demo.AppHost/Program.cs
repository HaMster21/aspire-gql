var builder = DistributedApplication.CreateBuilder(args);

var dbConnection = builder.AddConnectionString("BookstoreDb");

var api = builder
    .AddProject<Projects.AspireDemo>("aspiredemo")
    .WithReference(dbConnection);

builder.Build().Run();
