namespace Recipe.Application.Common.Interfaces.Persistence
{
    using Recipe.Domain.ValueObjects;

    public interface IRecipeRepository
    {
        Task<Domain.RecipeAggregate.Recipe?> GetAsync(RecipeId id);
        Task<IEnumerable<Domain.RecipeAggregate.Recipe>> GetAllUserRecipes(string userId);
        Task UpdateAsync(Domain.RecipeAggregate.Recipe recipe);
        Task AddAsync(Domain.RecipeAggregate.Recipe recipe);
    }
}
