using FluentValidation;
using Mag.Api.Common.Errors;
using Mag.Api.Common.Mapping;
using Mag.Api.Common.Marker;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        services.AddSingleton<ProblemDetailsFactory, MagProblemDetailsFactory>();
        services.AddValidatorsFromAssemblyContaining(typeof(IAssemblyMarker));

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