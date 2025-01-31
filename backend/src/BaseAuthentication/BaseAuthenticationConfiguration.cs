using System.Text;
using BaseAuthentication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BaseAuthentication;

public static class BaseAuthenticationConfiguration
{
    public static IServiceCollection AddBaseAuthentication(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        var secretKey = configurationManager.GetSection("JWTAuthentication:Secret")?.Value ?? "";

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                };
            });
        
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<ITokenService, TokenService>();
        
        return services;
    }
}