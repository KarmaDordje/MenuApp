namespace Recipe.Infrastructure.Persistence
{
    using System.Collections.Generic;


    using Microsoft.EntityFrameworkCore;

    using Recipe.Application.Common.Interfaces.Persistence;
    using Recipe.Domain.RecipeAggregate;

    using Recipe.Domain.ValueObjects;

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

        public async Task<IEnumerable<Recipe>> GetAllUserRecipes(string userId)
        {
            return await _context.Recipes.Where(r => r.UserId == userId).ToListAsync();
        }


        public async Task<Domain.RecipeAggregate.Recipe?> GetAsync(RecipeId id)
        {
            return await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateAsync(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
        }

    }
}