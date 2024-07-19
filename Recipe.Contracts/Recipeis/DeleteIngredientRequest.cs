namespace Recipe.Contracts.Recipes
{
    public record DeleteIngredientRequest(string RecipeId, string RecipeSectionId, string IngredientId);

}