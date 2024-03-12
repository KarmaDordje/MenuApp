using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.Interfaces;
using Recipe.Application.Mappings;
using Recipe.Application.Services;
using Recipe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Application
{
    public static class DependencyInjection
    {   
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
