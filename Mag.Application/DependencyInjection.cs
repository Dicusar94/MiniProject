using Mag.Application.Common.Interfaces;
using Mag.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Mag.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        return services;
    }
}