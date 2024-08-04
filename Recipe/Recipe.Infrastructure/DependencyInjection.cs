namespace Recipe.Infrastructure
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
            //services.AddMessageBus();
            // services.AddScoped<IIngredientRepository, IngredientRepository>();
            return services;
        }

        public static IServiceCollection AddMessageBus(this IServiceCollection services)
        {

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://91.228.56.38", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });
                    cfg.ConfigureEndpoints(context);
                });
            });
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Postgress");
            services.AddScoped<PublishDomainEventsInterceptor>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddDbContext<RecipeDbContext>(options => options.UseNpgsql(connectionString!));
            return services;
        }

    }
}
