namespace Menu.Application
{
    using System.Reflection;
    using FluentValidation;
    using global::Menu.Application.Common.Behaviors;
    using global::Menu.Application.Common.Intefaces.CreareMenu;

    using global::Menu.Application.Services;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddScoped<ICreateMenuService, CreateMenuService>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}