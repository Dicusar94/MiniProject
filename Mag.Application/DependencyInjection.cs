using Mag.Application.Common.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mag.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddMappings();
        return services;
    }
}