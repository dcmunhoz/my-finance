using BaseAuthentication;
using Identity.Api.Data.Context;
using Identity.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddBaseAuthentication(builder.Configuration);

builder.Services.AddTransient<HashService>();

builder.Services.AddDbContext<IdentityDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("IDENTITY")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

    
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod() );
app.UseAuthorization();
app.MapControllers();

app.Run();