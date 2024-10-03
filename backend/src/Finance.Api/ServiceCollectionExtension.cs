using Api.Core.Filters;
using Notification;

namespace Finance.Api;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        // services.AddTransient<NotificationFilter>();
        services.AddControllers(opt => 
            opt.Filters.Add(typeof(NotificationFilter)) 
        );
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}