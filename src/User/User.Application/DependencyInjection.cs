namespace User.Application
{
    using System.Reflection;
    using FluentValidation;
    using global::User.Application.Common.Behavior;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using global::User.Domain.UserAggregate;
    using global::User.Application.User.Commands;

    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient<IUsersCounter, UsersCounter>();
            return services;
        }
    }
}