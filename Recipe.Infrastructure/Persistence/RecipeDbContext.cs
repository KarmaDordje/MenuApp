using Microsoft.EntityFrameworkCore;

using Recipe.Domain.Common.Models;

using Recipe.Infrastructure.Persistence.Interceptors;

namespace Recipe.Infrastructure.Persistence
{
    public class RecipeDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor)
        : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<Domain.RecipeAggregate.Recipe> Recipes { get; set; }
        public DbSet<Domain.IngredientAggregate.Product> Ingredients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Ignore<List<IDomainEvent>>()
            .ApplyConfigurationsFromAssembly(typeof(RecipeDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
        }
    }
}