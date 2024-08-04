namespace Menu.Infrastructure
{
    using MassTransit;
    using Menu.Domain.MenuAggregate;
    using Menu.Infrastructure.Common;
    using Menu.Infrastructure.Persistance;
    using Menu.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Postgress");
            services.AddScoped<IMenuRepositury, MenuRepository>();
            services.AddDbContext<MenuDbContext>(options => options.UseNpgsql(connectionString!));
            services.AddMessageBus();
            return services;
        }

         public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {

                x.UsingRabbitMq((context, cfg) =>
                {
                    // Retrieve RabbitMQ configuration from IConfiguration
                    var configuration = ConfigurationLoader.LoadConfiguration();
                    var rabbitMQSettings = configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

                    cfg.Host(new Uri($"rabbitmq://{rabbitMQSettings.Host}:5672"), h =>
                    {
                        h.Username(rabbitMQSettings.Username);
                        h.Password(rabbitMQSettings.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }
    }
}
