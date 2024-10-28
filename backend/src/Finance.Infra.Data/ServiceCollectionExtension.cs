using Finance.Application.Queries;
using Finance.Application.Repositories;
using Finance.Infra.Data.Queries;
using Finance.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Infra.Data;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<FinanceDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            
            // TODO: REMOVE THIS
            opt.LogTo(Console.WriteLine);
        });
        
        services.AddRepositories();
        services.AddQueries();
        
        return services;
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
    }

    private static void AddQueries(this IServiceCollection services)
    {
        services.AddTransient<ICategoryQuery, CategoryQuery>();
    }
}