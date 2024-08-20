namespace User.Infrastructure
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SharedCore.Data;
    using User.Domain.UserAggregate;
    using User.Infrastructure.Persistance;

    using User.Infrastructure.Repositories;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Postgress");
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<UserDbContext>(options => options.UseNpgsql(connectionString!));

            services.AddTransient<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connectionString!));
            return services;
        }

    }
}
