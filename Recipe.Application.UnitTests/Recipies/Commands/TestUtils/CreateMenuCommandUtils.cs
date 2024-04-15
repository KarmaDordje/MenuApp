namespace Recipe.Application.UnitTests.Recipies.Commands.TestUtils;

using Recipe.Application.UnitTests.TestUnits.Constants;

using Recipe.Application.Recipes.Commands.CreateRecipe;
public static class CreateRecipeCommandUtils
{
    public static CreateRecipeCommand CreateCommand(
        List<CreateIngredientCommand>? ingridients = null,
        List<CreateRecipeStepCommand>? recipeSteps = null
    ){
        return new CreateRecipeCommand(
            Constants.Recipe.Name,
            Constants.Recipe.UserId,
            Constants.Recipe.Description,
            Constants.Recipe.ImageUrl,
            Constants.Recipe.VideoUrl,
            recipeSteps ?? CreateRecipeStepsCommand(),
            ingridients ?? CreateIngredientsCommand());
    }

    public static List<CreateIngredientCommand> CreateIngredientsCommand(int sectionCount = 5) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateIngredientCommand(
                Constants.Recipe.IngredientNameFromIndex(index),
                Constants.Recipe.IngredientQuantityFromIndex(index)))
            .ToList();
    public static List<CreateRecipeStepCommand> CreateRecipeStepsCommand(int sectionCount = 5) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new CreateRecipeStepCommand(
                index,
                Constants.Recipe.RecipeStepNameFromIndex(index)))
            .ToList();
}