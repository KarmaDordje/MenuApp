namespace Recipe.Contracts.Ingredients
{
    public record CreateIngredientRequest(string IngredientName, decimal Quantity, string RecipeId);
}