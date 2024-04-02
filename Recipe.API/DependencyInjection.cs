using Recipe.Api.Common.Mapping;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        //services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}