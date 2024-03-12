using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Interfaces;
using Recipe.Infrastructure.Context;
using Recipe.Infrastructure.Repositories;
using Recipe.Infrastructure.External;

namespace RecipeMicroservice.Configuration
{
    public static class DependencyInjection
    {
        public static void AddApi(this IServiceCollection services, IConfiguration configuration)
        {
           
            //services.AddScoped<IIngredientRepository, IngredientRepository>();
            //services.AddScoped<IIngredientService, IngredientService>();

            //services.AddSingleton<INutritionClient, NutritionApiClient>(provider =>
            //{
            //    var baseUrl = Environment.GetEnvironmentVariable("NUTRITION_API_BASE_URL");
            //    var apiKey = Environment.GetEnvironmentVariable("NUTRITION_API_KEY");
            //    string headerName = "X-Api-Key";
            //    return new NutritionApiClient(baseUrl, apiKey, headerName);
            //});
            //services.AddSingleton<IDeepLClient, DeepLApiClient>(provider =>
            //{
            //    var baseUrl = Environment.GetEnvironmentVariable("DEEPL_API_BASE_URL");
            //    var apiKey = Environment.GetEnvironmentVariable("DEEPL_API_KEY");
            //    string headerName = "Authorization";
            //    return new DeepLApiClient(baseUrl, apiKey, headerName);
            //});
            //services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

        }
    }
}
