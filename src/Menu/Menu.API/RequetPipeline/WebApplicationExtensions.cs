namespace Menu.API.RequestPipeline
{
    using Microsoft.AspNetCore.Diagnostics;
    public static class WebApplicationExtensions
    {
        public static WebApplication UseGlobalErrorHandling(this WebApplication app)
    {
        app.UseExceptionHandler("/error");

        app.Map("/error", (HttpContext httpContext) =>
        {
            Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception is null)
            {
                // handling this unexpected case
                return Results.Problem();
            }

            // custom global error handling logic
            return Results.Problem();
        });

        return app;
    }
    }
}