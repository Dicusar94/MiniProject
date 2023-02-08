using Mag.Application.Common.Interfaces.Persistence;
using Mag.Infrastructure.Persistence;
using Mag.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mag.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IProductRepository, ProductRepositorySql>();
        services.AddDbContext<MagContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}