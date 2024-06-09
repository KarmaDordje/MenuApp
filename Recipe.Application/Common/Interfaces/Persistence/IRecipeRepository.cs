using Recipe.Domain.ValueObjects;

namespace Recipe.Application.Common.Interfaces.Persistence
{
    public interface IRecipeRepository
    {
        Task<Domain.RecipeAggregate.Recipe?> GetAsync(RecipeId id);
        Task UpdateAsync(Domain.RecipeAggregate.Recipe recipe);
        Task AddAsync(Domain.RecipeAggregate.Recipe recipe);
    }
}
