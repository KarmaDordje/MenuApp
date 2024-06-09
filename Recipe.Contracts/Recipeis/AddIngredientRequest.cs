namespace Recipe.Contracts.Recipes
{
    public record AddIngredientRequest(Guid RecipeId, string IngredientName, decimal Quantity);
}