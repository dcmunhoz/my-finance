using Finance.Application.Common.Interface.Queries;
using Finance.Application.Common.Interface.Repository;
using Finance.Infra.Database.Persistence;
using Finance.Infra.Database.Persistence.Queries;
using Finance.Infra.Database.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        
        return services;
    }

    private static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FinanceDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("FINANCE")));
        
        services.AddRepositories();
        services.AddQueries();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IReasonRepository, ReasonRepository>();
    }

    private static void AddQueries(this IServiceCollection services)
    {
        services.AddTransient<ICategoryQuery, CategoryQuery>();
    }
}