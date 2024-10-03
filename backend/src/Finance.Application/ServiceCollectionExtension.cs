using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Notification;

namespace Finance.Application;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        services.AddNotificationService();
        
        return services;
    }
}