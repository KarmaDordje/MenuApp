﻿namespace Recipe.Infrastructure
{
    using MassTransit;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Application.Interfaces;
    using Recipe.Application.Interfaces.Persistence;
    using Recipe.Domain.Persistence;
    using Recipe.Infrastructure.External;
    using Recipe.Infrastructure.Messaging;
    using Recipe.Infrastructure.Persistence;
    using Recipe.Infrastructure.Persistence.Interceptors;
    using Recipe.Infrastructure.Persistence.Repositories;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<INutritionClient, NutritionApiClient>(provider =>
            {
                var baseUrl = Environment.GetEnvironmentVariable("NUTRITION_API_BASE_URL");
                var apiKey = Environment.GetEnvironmentVariable("NUTRITION_API_KEY");
                string headerName = "X-Api-Key";
                return new NutritionApiClient(baseUrl, apiKey, headerName);
            });

            services.AddSingleton<IDeepLClient, DeepLApiClient>(provider =>
            {
                var baseUrl = Environment.GetEnvironmentVariable("DEEPL_API_BASE_URL");
                var apiKey = Environment.GetEnvironmentVariable("DEEPL_API_KEY");
                string headerName = "Authorization";
                return new DeepLApiClient(baseUrl, apiKey, headerName);
            });

            services.AddPersistence();
            services.AddMessageBus();
            return services;
        }

        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<GetRecipeConsumer>();
                x.UsingRabbitMq((context, cfg) =>
                {
                    // Retrieve RabbitMQ configuration from IConfiguration
                    var configuration = ConfigurationLoader.LoadConfiguration();
                    var rabbitMQSettings = configuration.GetSection("RabbitMQ").Get<RabbitMQSettings>();

                    cfg.Host(new Uri($"rabbitmq://{rabbitMQSettings.Host}:5672"), "/", h =>
                    {
                        h.Username(rabbitMQSettings.Username);
                        h.Password(rabbitMQSettings.Password);

                        cfg.ReceiveEndpoint($"{typeof(DependencyInjection).Namespace}", e =>
                        {
                            e.ConfigureConsumer<GetRecipeConsumer>(context);
                        });
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            // Retrieve configuration
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Postgress");

            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddDbContext<RecipeDbContext>(options => options.UseNpgsql(connectionString, op => op.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            return services;
        }
    }
}
