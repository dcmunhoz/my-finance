using Finance.Api;
using Finance.Application;
using Finance.Infra.Data;

// Services
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

// Web application
var app = builder.Build();

app.UseApi().Run();