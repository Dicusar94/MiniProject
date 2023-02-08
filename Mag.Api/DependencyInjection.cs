using Mag.Api.Common.Mapping;

namespace Mag.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddCustomCors("AllowAllOrigins");
        services.AddMappings();

        return services;
    }

    public static IServiceCollection AddCustomCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        return services;
    }
}