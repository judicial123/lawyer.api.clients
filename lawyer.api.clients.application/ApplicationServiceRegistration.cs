using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace lawyer.api.clients.application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registro de AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Registro de MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}