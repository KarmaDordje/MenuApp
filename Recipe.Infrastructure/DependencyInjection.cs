using Microsoft.Extensions.DependencyInjection;

using Recipe.Application.Interfaces;
using Recipe.Domain.Persistence;
using Recipe.Infrastructure.External;
//using Recipe.Infrastructure.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Infrastructure
{
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
            // services.AddScoped<IIngredientRepository, IngredientRepository>();
            return services;
        }
    }
}
