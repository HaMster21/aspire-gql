var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireDemo>("aspiredemo");

builder.Build().Run();
