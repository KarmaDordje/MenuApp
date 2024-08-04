namespace Recipe.Contracts.Recipes
{
    public record RecipeResponse(
        string Id,
        string Name,
        string Description,
        float AvarageRating,
        string ImageUrl,
        string VideoUrl,
        List<RecipeSectionResponse> RecipeSections,
        List<RecipeStepResponse> RecipeSteps,
        DateTime CreatedAt,
        DateTime UpdatedAt);

    public record RecipeSectionResponse(
        string Id,
        string Title,
        List<RecipeIngredientResponse> Ingredients);

    public record RecipeIngredientResponse(
        string Id,
        string PolishName,
        decimal Calories,
        decimal Cholesterol,
        decimal FatSaturated,
        decimal FatTotal,
        decimal Potassium,
        decimal Protein,
        decimal Sodium,
        decimal Sugar,
        string Quantity,
        string Unit);

    public record RecipeStepResponse(
        string Id,
        int Order,
        string Name,
        string ImageUrl,
        string VideoUrl);

}