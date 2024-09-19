using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        
        return services;
    }
}