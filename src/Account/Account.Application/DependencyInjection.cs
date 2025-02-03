using Account.Application.Application.Mappings;
using Account.Application.Common.Behavior;
using Account.Domain.AccountRegistrationAggregate;


namespace Account.Application
{
    using System.Reflection;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;


    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddScoped<IAccountsCounter, AccountCounter>();
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
