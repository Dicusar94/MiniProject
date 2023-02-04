using Mag.Application.Common.Interfaces;
using Mag.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Mag.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}