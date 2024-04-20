using Recipe.Application.Common.Interfaces.Persistence;

namespace Recipe.Infrastructure.Persistence
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext context)
        {
            _context = context;
        }

        public void AddAsync(Domain.RecipeAggregate.Recipe recipe)
        {
            _context.Add(recipe);
            _context.SaveChanges();
        }
    }
}