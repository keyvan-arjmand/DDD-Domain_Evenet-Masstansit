using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Contracts;
using User.Infrastructure.Persistence;
using User.Infrastructure.Repository;

namespace User.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {


        MongoDbPersistence.Configure();
        services.AddScoped<IRepository<Domain.Entities.User>, Repository<Domain.Entities.User>>();
        return services;
    }
}