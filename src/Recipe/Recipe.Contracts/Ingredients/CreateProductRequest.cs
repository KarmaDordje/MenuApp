namespace Recipe.Contracts.Ingredients
{
    public record CreateProductRequest(string IngredientName, decimal Quantity, string RecipeId);
}