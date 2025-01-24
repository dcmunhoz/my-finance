using System.Reflection;
using Common.Application.Behaviours;
using MediatR;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddCommonApplication(this IServiceCollection services, Assembly assembly)
    {
        services.AddCommonMediatr(assembly);
        
        return services;
    }

    private static IServiceCollection AddCommonMediatr(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        return services;
    }
}