namespace Recipe.Application.Common.Interfaces.Persistence
{
    public interface IRecipeRepository
    {
        void AddAsync(Domain.RecipeAggregate.Recipe recipe);
    }
}

