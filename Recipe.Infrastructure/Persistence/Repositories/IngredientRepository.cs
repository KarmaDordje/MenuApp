using Microsoft.EntityFrameworkCore;
using Recipe.Application.Interfaces.Persistence;
using Recipe.Domain.IngredientAggregate;
using Recipe.Domain.IngredientAggregate.ValueObjects;


namespace Recipe.Infrastructure.Persistence.Repositories;

public class IngredientRepository : IIngredientRepository
{
    private readonly RecipeDbContext _recipeDbContext;

    public IngredientRepository(RecipeDbContext recipeDbContext)
    {
        _recipeDbContext = recipeDbContext;
    }

    public async Task AddAsync(Product ingredient)
    {
        await _recipeDbContext.Ingredients.AddAsync(ingredient);
        await _recipeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Product ingredient)
    {
        _recipeDbContext.Ingredients.Remove(ingredient);
        await _recipeDbContext.SaveChangesAsync();
    }

    public async Task<Product> GetAsync(string id)
    {
        return await _recipeDbContext?.Ingredients?.FirstOrDefaultAsync(i => i.Id.Value == id);
    }

    public async Task<Product> GetAsyncByIngredientName(string ingredientName)
    {
        return await _recipeDbContext.Ingredients.FirstOrDefaultAsync(i => i.PolishName == ingredientName) ?? null;
    }

    public async Task<IEnumerable<Product>> GetIngredientsAsync()
    {
        return await _recipeDbContext.Ingredients.ToListAsync();
    }

    public async Task UpdateAsync(Product ingredient)
    {
        _recipeDbContext.Ingredients.Update(ingredient);
        await _recipeDbContext.SaveChangesAsync();
    }
}