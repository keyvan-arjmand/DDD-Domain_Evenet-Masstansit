using MassTransit;
using User.Domain.Event;

namespace User;

public static class ConfigureServices
{
    public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddMassTransit(x =>
        {
            //x.AddConsumer<UserToCreateConsumer>();
            var entryAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName.Contains("User.Application"));
            x.AddConsumers(entryAssembly);
            x.SetKebabCaseEndpointNameFormatter();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMqSettings:Host"], configuration["RabbitMqSettings:VirtualHost"], h =>
                {
                    h.Username(configuration["RabbitMqSettings:Username"]);
                    h.Password(configuration["RabbitMqSettings:Password"]);
                });
                cfg.UseDelayedRedelivery(r => r.Intervals(TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(15), TimeSpan.FromMinutes(30)));
                cfg.UseMessageRetry(r => r.Immediate(5));
                cfg.UseInMemoryOutbox();
                cfg.ConfigureEndpoints(context);
            });
            
        });
        return services;
    }
}