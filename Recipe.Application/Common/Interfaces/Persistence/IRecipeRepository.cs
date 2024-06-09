namespace Recipe.Application.Common.Interfaces.Persistence
{
    public interface IRecipeRepository
    {
        Task<Domain.RecipeAggregate.Recipe?> GetAsync(Guid id);
        Task AddAsync(Domain.RecipeAggregate.Recipe recipe);
    }
}
