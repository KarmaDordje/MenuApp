namespace Recipe.Contracts.Recipes
{
    public record AddIngredientRequest(string RecipeId, string RecipeSectionId, string IngredientName, decimal Quantity);
}