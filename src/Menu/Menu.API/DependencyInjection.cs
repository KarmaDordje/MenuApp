namespace Menu.API
{
    using Menu.API.Common.Mapping;

    public static class DependencyInjection
    {
        public static IServiceCollection AddGlobalErrorHandling(
        this IServiceCollection services)
        {
            services.AddProblemDetails(options =>
            {
                options.CustomizeProblemDetails = context =>
                {
                    context.ProblemDetails.Extensions["traceId"] = context.HttpContext.TraceIdentifier;
                };
            });
            services.AddPresentation();
            services.AddAutoMapper(typeof(MenuMappingConfig));
            return services;
        }

        public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        //services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        //services.AddMappings();
        return services;
    }
    }
}