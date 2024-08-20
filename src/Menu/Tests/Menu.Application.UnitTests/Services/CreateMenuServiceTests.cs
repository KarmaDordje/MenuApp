namespace Menu.Application.UnitTests.Services;

using FluentAssertions;
using global::Menu.Application.Services;
using global::Menu.Application.UnitTests.TestUtils.Constants;
using global::Menu.Domain.MenuAggregate.Entities;
using global::Menu.Application.UnitTests.Services.TestUtils;
using global::Menu.Domain.MenuAggregate;
using Bogus.DataSets;
using System.Globalization;
using global::Menu.Domain.Common.Shared;

public class CreateMenuServiceTests
{   
    private CreateMenuService _sut;
    public CreateMenuServiceTests()
    {
        _sut = new CreateMenuService();
    }

    [Fact]
    public void GenerateMenu_WhenCalled_ShouldReturnMenu() 
    {
        // Arrange
        string userId = "cc0ba5fd-598f-4cd2-b834-fd9b2d61fa19";
        DateTime startDate = DateTime.Now; 
        int daysCount = 5;
        List<MealCategory> mealCategories = new List<MealCategory> { MealCategory.Breakfast, MealCategory.Lunch };
        List<Contracts.Menu.RecipeDTO> recipes = CreateMenuServiceUtils.CreateRecipies(10);

        // Act
        var result = _sut.GenerateMenu(userId, startDate, daysCount, mealCategories, recipes);

        // Assert
        result.Should().NotBeNull();
        result.Value.MenuDays.Should().NotBeEmpty();
    }
}