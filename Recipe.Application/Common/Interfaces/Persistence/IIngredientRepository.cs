using Recipe.Domain.IngredientAggregate;
using Recipe.Domain.IngredientAggregate.ValueObjects;

namespace Recipe.Application.Interfaces.Persistence
{
    public interface IIngredientRepository
    {
        Task<Product> GetAsync(string id);
        Task<Product> GetAsyncByIngredientName(string ingredientName);
        Task AddAsync(Product ingredient);
        Task UpdateAsync(Product ingredient);
        Task DeleteAsync(Product ingredient);
    }
}
