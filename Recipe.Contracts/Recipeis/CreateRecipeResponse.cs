using Recipe.Domain.ValueObjects;

namespace Recipe.Contracts.Recipes
{
    public record CreateRecipeResponse(
        string RecipeId,
        string Name,
        string Description,
        float AvarageRating,
        string Image,
        string VideoUrl,
        List<StepResponse> Steps,
        List<IngredientResponse> Ingredients,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );

    public record IngredientResponse(
        string IngredientId,
        string Name,
        string PolishName,
        decimal Calories,
        decimal Cholesterol,
        decimal FatSaturated,
        decimal FatTotal,
        int MeasuresType,
        decimal Potassium,
        decimal Protein,
        decimal Sodium,
        Measurement Measurement
    );

    public record StepResponse(string Name, string Order);
}