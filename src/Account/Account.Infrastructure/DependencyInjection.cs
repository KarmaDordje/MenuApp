using Account.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure
{
    using Account.Domain.AccountRegistrationAggregate;
    using Account.Infrastructure.Persistance.Configurations.Repositories;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SharedCore.Data;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddPersistence();

            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            // Retrieve configuration
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Postgress");
            services.AddDbContext<AccountDbContext>(options => options.UseNpgsql(connectionString!));
            services.AddScoped<IAccountRegistrationsRepository, AccountRegistrationsRepository>();
            services.AddTransient<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString!));
            return services;
        }
    }
}
