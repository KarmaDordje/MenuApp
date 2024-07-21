namespace Recipe.Application.Interfaces.Persistence
{
    using Recipe.Domain.IngredientAggregate;
    using Recipe.Domain.IngredientAggregate.ValueObjects;

    public interface IIngredientRepository
    {
        Task<Product> GetAsync(string id);
        Task<Product> GetAsyncByIngredientName(string ingredientName);
        Task<List<Product>> GetByIds(IEnumerable<ProductId> productIds);
        Task AddAsync(Product ingredient);
        Task UpdateAsync(Product ingredient);
        Task DeleteAsync(Product ingredient);
    }
}
