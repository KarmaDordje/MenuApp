using FluentAssertions;

using Recipe.Application.Recipes.Commands.CreateRecipe;
using Recipe.Domain.RecipeAggregate;

namespace Recipe.Application.UnitTests.TestUnits.Extensions;

public static partial class MenuExtensions
{
    public static void ValidateCreatedFrom(this Domain.RecipeAggregate.Recipe recipe, CreateRecipeCommand command)
    {
        recipe.Name.Should().Be(command.Name);
        recipe.UserId.Should().Be(command.UserId);
        recipe.Description.Should().Be(command.Description);
        recipe.ImageUrl.Should().Be(command.ImageUrl);
        recipe.VideoUrl.Should().Be(command.VideoUrl);
        recipe.RecipeSteps.Should().HaveCount(command.RecipeSteps.Count);
        recipe.Ingredients.Should().HaveCount(command.Ingredients.Count);
    }
}