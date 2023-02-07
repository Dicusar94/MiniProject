using Mag.Application.Common.Interfaces.Markers;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Mag.Application.Common.Mapping;

public static class DependencyInjection
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(IApplicationAssemblyMarker).Assembly);

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}