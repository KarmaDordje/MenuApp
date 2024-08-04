namespace Menu.Infrastructure
{
    using Menu.Domain.MenuAggregate;
    using Menu.Infrastructure.Persistance;
    using Menu.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("Postgress");
            services.AddScoped<IMenuRepositury, MenuRepository>();
            services.AddDbContext<MenuDbContext>(options => options.UseNpgsql(connectionString!));
            return services;
        }
    }
}
