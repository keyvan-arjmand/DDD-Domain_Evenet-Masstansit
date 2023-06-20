using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace User.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}
