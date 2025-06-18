using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace lawyer.api.clients.application
{
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
}