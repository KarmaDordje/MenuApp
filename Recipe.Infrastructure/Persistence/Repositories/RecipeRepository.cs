namespace Recipe.Infrastructure.Persistence
{
    using Microsoft.EntityFrameworkCore;


    using Recipe.Application.Common.Interfaces.Persistence;

    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Domain.RecipeAggregate.Recipe recipe)
        {
            _context.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.RecipeAggregate.Recipe?> GetAsync(Guid id)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id.Value == id);
        }
    }
}