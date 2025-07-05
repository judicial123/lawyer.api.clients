using lawyer.api.clients.application.Contracts.Interfaces.Persistence.Client;
using lawyer.api.clients.datastore.mssql.DatabaseContext;
using lawyer.api.clients.datastore.mssql.Model.MappingProfiles;
using lawyer.api.clients.datastore.mssql.Repositories.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace lawyer.api.clients.datastore.mssql;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<LawyersContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("LawyersConnectionString")));

        services.AddAutoMapper(typeof(ApplicationMappingProfile).Assembly);

        services.AddScoped<IClientCommandRepository, ClientCommandRepository>();
        services.AddScoped<IClientQueryRepository, ClientQueryRepository>();

        return services;
    }
}