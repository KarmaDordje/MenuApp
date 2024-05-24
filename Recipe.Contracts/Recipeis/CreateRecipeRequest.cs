namespace Recipe.Contracts.Recipes
{
    public record CreateRecipeRequest(
        string Name,
        string UserId);
}