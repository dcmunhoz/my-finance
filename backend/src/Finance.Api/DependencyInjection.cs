using BaseAuthentication;
using Finance.Api.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddOpenApi();
        services.AddBaseAuthentication(configuration);

        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<TokenService>();

        return services;
    }
}