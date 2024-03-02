using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Interfaces;
using Recipe.Domain.Services;
using Recipe.Infrastructure.Context;
using Recipe.Infrastructure.Interfaces;
using Recipe.Domain.Mappings;
using Recipe.Infrastructure.Repositories;

namespace RecipeMicroservice.Configuration
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureApi(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("WebApiDatabase");

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IIngredientService, IngredientService>();

            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

        }
    }
}
