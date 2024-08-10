namespace Menu.Application.UnitTests.Services;

using FluentAssertions;
using global::Menu.Application.Services;
using global::Menu.Application.UnitTests.TestUtils.Constants;
using global::Menu.Domain.MenuAggregate.Entities;
using global::Menu.Application.UnitTests.Services.TestUtils;
using global::Menu.Domain.MenuAggregate;
using Bogus.DataSets;
using System.Globalization;


public class CreateMenuServiceTests
{   
    private CreateMenuService _sut;
    public CreateMenuServiceTests()
    {
        _sut = new CreateMenuService();
    }
    [Fact]
    public void CreateMenuAsync_WithValidData_ShouldCreateMenu()
    {
        // Arrange
        // Act
        var result = _sut.CreateMeal(
            Constants.Meal.RecipeName,
            Constants.Meal.RecipeDescription,
            Constants.Meal.RecipeImageUrl,
            Constants.Meal.MenyType,
            Constants.User.UserId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Meal>();
    }

    [Fact]
    public void CreateMenuDay_WithValidaData_ShouldCreateMenuDay()
    {
        // Arrange

        // Act

        var result = _sut.CreateMenuDay(
            1,
            DateTime.Now,
            CreateMenuServiceUtils.CreateMeal(2));

        // Asserion

        result.Should().NotBeNull();
        result.DayOfWeek.Should().ContainAll(DateTime.Now.AddDays(1).DayOfWeek.ToString(new CultureInfo("pl-PL")));
        result.Should().BeOfType<MenuDay>();
    }

    [Fact]
    public void CreateMenu_WithValidData_ShouldCreateMenu()
    {
        // Arrange

        // Act

        // var result = _sut.CreateMenu(
        //     Constants.Menu.MenuName,
        //     Constants.Menu.MenuDescription,
        //     Constants.User.UserId,
        //     DateTime.Now,
        //     5,

        //     CreateMenuServiceUtils.CreateMenuDay(2)
        // );

        // // Assert

        // result.Should().NotBeNull();
        // result.Should().BeOfType<Menu>();
        // result.MenuDays.Should().HaveCount(2);
    }
}