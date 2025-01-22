var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApi(builder.Configuration)
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();