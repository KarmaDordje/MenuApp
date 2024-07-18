namespace Recipe.Contracts.Recipes
{
    public record AddIngredientRequest(Guid RecipeId, Guid RecipeSectionId, string IngredientName, decimal Quantity);
}