using FluentAssertions;
using Moq;
using Recipe.Application.Common.Interfaces.Persistence;
using Recipe.Application.Recipes.Commands.CreateRecipe;
using Recipe.Application.UnitTests.Recipies.Commands.TestUtils;
using Recipe.Application.UnitTests.TestUnits.Extensions;

namespace Recipe.Application.UnitTests.Recipies.Commands.CreateRecipe;


public class CreateRecipeCommandHandlerTests
{
    private readonly Mock<IRecipeRepository> __mockMenuRepository;
    private readonly CreateRecipeCommandHandler _handler;

    public CreateRecipeCommandHandlerTests()
    {
        __mockMenuRepository = new Mock<IRecipeRepository>();
        _handler = new CreateRecipeCommandHandler(__mockMenuRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidCreateRecipeCommands))]
    public async Task HandleCreateRecipeCommand_WhenRecipeIsValid_ShouldCreateAndReturnMenu(CreateRecipeCommand createRecipeCommand)
    {

        // Act
        var result = await _handler.Handle(createRecipeCommand, CancellationToken.None);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createRecipeCommand);
        __mockMenuRepository.Verify(x => x.AddAsync(result.Value), Times.Once);

    }

    public static IEnumerable<object[]> ValidCreateRecipeCommands()
    {
        yield return new object[] { CreateRecipeCommandUtils.CreateCommand() };
        yield return new object[]
        {
            CreateRecipeCommandUtils.CreateCommand(
            recipeSteps: CreateRecipeCommandUtils.CreateRecipeStepsCommand(3),
            ingridients: CreateRecipeCommandUtils.CreateIngredientsCommand(32)),
            };
    }

}