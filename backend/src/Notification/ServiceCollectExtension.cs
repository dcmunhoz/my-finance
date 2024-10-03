using Microsoft.Extensions.DependencyInjection;

namespace Notification;

public static class ServiceCollectExtension
{
    public static IServiceCollection AddNotificationService(this IServiceCollection services)
    {
        services.AddScoped<INotificationHandler, NotificationHandler>();
        
        return services;
    }
}