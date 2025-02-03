using Account.API.Common.Mapping;
namespace Account.API
{
    

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
            services.AddAutoMapper(typeof(AccountMappingConfig));
            return services;
        }

        public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        return services;
    }
    }
}