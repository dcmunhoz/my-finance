using Finance.Application.Repositories;
using Finance.Infra.Persistence;
using Finance.Infra.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Infra;

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
        
        AddRepositories(services);
        
        return services;
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
    }
}