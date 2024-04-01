using FluentValidation;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

using Recipe.Application.Common.Behavior;
using Recipe.Application.Ingredients.Commands.AddIngredient;
using Recipe.Application.Interfaces;
using Recipe.Application.Mappings;
using Recipe.Application.Services;
using Recipe.Domain.Dtos;

using System.Reflection;

namespace Recipe.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddTransient<INutritionCalculationService, NutritionCalculationService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}
