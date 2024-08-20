namespace Recipe.Contracts.Recipes
{
    using Recipe.Domain.ValueObjects;

    public record CreateRecipeResponse(
        Guid RecipeId,
        Guid RecipeSectionId);
}