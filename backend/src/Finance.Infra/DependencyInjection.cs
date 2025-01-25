using Finance.Application.Common.Interface.Repository;
using Finance.Infra.Database.Persistence;
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

        services.AddTransient<ICategoryRepository, CategoryRepository>();

    }
}