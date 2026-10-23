using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AgenticEngineer.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceExtensions).Assembly));

        services.AddAutoMapper(cfg => cfg.AddMaps(typeof(ApplicationServiceExtensions).Assembly));

        return services;
    }
}