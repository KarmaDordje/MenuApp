using Microsoft.EntityFrameworkCore;

namespace Recipe.Infrastructure.Persistence
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options)
        {
        }

        public DbSet<Domain.Entities.Recipe> Recipes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeDbContext).Assembly);
        }
    }
}