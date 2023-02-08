using Mag.Api.Common.Marker;
using Mapster;
using MapsterMapper;

namespace Mag.Api.Common.Mapping;

public static class DependencyInjection
{
        public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(IAssemblyMarker).Assembly);
        return services;
    }
}