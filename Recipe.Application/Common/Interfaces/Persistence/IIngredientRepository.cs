using Recipe.Domain.IngredientAggregate;
using Recipe.Domain.IngredientAggregate.ValueObjects;

namespace Recipe.Application.Interfaces.Persistence
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetAsync(string id);
        Task<Ingredient> GetAsyncByIngredientName(string ingredientName);
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(Ingredient ingredient);
    }
}
