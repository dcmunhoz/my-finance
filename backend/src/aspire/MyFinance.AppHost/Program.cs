var builder = DistributedApplication.CreateBuilder(args);

var sqlServer = builder.AddSqlServer("aspire-db-my-finance", port: 1433)
    .WithLifetime(ContainerLifetime.Persistent);

var identityContextDb = sqlServer.AddDatabase("IDENTITY");
var identity = builder.AddProject<Projects.Identity_Api>("identity-api")
    .WithReference(identityContextDb)
    .WaitFor(identityContextDb);

var financeContextDb = sqlServer.AddDatabase("FINANCE");
var finance = builder.AddProject<Projects.Finance_Api>("finance-api")
    .WaitFor(identity)
    .WithReference(financeContextDb)
    .WaitFor(financeContextDb);

var angular = builder.AddNpmApp("my-finance-presentation", "../../../../frontend", "start:aspire")
    .WaitFor(identity)
    .WithReference(identity)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints();

builder.Build().Run();