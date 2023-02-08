using Mag.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Mag.Api.Common.Extensions;

public static class AppBuilderExtensions
{
    public static IApplicationBuilder DbEnsureCreated(this IApplicationBuilder app)
    {
        using var serviceScoped = app
            .ApplicationServices
            .GetService<IServiceScopeFactory>()
            !.CreateScope();

        var context = serviceScoped.ServiceProvider.GetRequiredService<MagContext>();
        context.Database.Migrate();

        return app;
    }
}