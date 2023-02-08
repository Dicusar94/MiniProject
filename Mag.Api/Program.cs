using Mag.Api;
using Mag.Api.Common.Extensions;
using Mag.Application;
using Mag.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;

    builder.Services
        .AddApplication()
        .AddInfrastructure(configuration)
        .AddPresentation();
}

var app = builder.Build();
{
    app.DbEnsureCreated();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAllOrigins");
    // app.UseHttpsRedirection();
    // app.UseAuthorization();
    app.MapControllers();
    app.Run();
}