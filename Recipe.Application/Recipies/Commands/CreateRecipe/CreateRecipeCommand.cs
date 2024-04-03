using ErrorOr;
using MediatR;

using Recipe.Domain.Entities;
using Recipe.Domain.ValueObjects;

namespace Recipe.Application.Recipes.Commands.CreateRecipe
{
    public record CreateRecipeCommand(
        string Name,
        int UserId,
        string Description,
        string ImageUrl,
        string VideoUrl,
        List<RecipeStep> RecipeSteps,
        List<Ingredient> Ingredients
    ) : IRequest<ErrorOr<Domain.Entities.Recipe>>;

    public record Ingredient(
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
    public record RecipeStep(int Order, string Name);
}