namespace Menu.Application.Services;

using System.Globalization;
using ErrorOr;
using global::Menu.Application.Common.Intefaces.CreareMenu;
using global::Menu.Domain.Common.Shared;
using global::Menu.Domain.MenuAggregate;
using global::Menu.Domain.MenuAggregate.Entities;
using global::Menu.Domain.Common.DomainErrors;

public class CreateMenuService : ICreateMenuService
{
    /// <summary>
    /// Creates a new Menu object.
    /// </summary>
    /// <param name="name">The name of the menu.</param>
    /// <param name="description">The description of the menu.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="startDate">The start date of the menu.</param>
    /// <param name="daysCount">The number of days the menu should cover.</param>
    /// <param name="mealCategories">The list of MealCategory objects representing the meal categories for the menu.</param>
    /// <param name="menuDays">The list of MenuDay objects representing each day of the menu.</param>
    /// <param name="recipes">The list of RecipeDTO objects representing the recipes for the menu.</param>
    /// <returns>The created Menu object.</returns>
    public ErrorOr<Menu> CreateMenu(
        string name,
        string description,
        string userId,
        DateTime startDate,
        int daysCount,
        List<MealCategory> mealCategories,
        List<MenuDay> menuDays,
        List<Contracts.Menu.RecipeDTO> recipes)
    {
        if (!ValidateIsEnoughRecipesForMenu(daysCount, recipes.Count, Enum.GetValues(typeof(MealCategory)).Length))
        {
            return Errors.Menu.NotEnoughtRecipies;
        }
        return Menu.Create(name, description, new UserId(new Guid(userId)), menuDays);
    }

    /// <summary>
    /// Creates a new Meal object.
    /// </summary>
    /// <param name="recipeName">The name of the recipe.</param>
    /// <param name="recipeDescription">The description of the recipe.</param>
    /// <param name="recipeImageUrl">The URL of the recipe image.</param>
    /// <param name="mealType">The type of the meal.</param>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>The created Meal object.</returns>
    public Meal CreateMeal(string recipeName, string recipeDescription, string recipeImageUrl, MealCategory mealType, string userId)
    {
        return Meal.Create(recipeName, recipeDescription, recipeImageUrl, mealType, new UserId(new Guid(userId)));
    }

    /// <summary>
    /// Creates a list of MenuDay objects.
    /// </summary>
    /// <param name="dayNumer">The number of days to create.</param>
    /// <param name="startFrom">The starting date.</param>
    /// <param name="date">The date of the created menu day.</param>
    /// <param name="meals">The list of meals for each menu day.</param>
    /// <returns>The created list of MenuDay objects.</returns>
    public List<MenuDay> CreateMenuDayList(int dayNumer, DateTime startFrom, DateTime date, List<Meal> meals)
    {
        var menuDays = new List<MenuDay>();
        for (int i = 0; i < (dayNumer - 1); i++)
        {
            menuDays.Add(CreateMenuDay(i, startFrom.AddDays(i), meals));
        }

        return menuDays;
    }

    /// <summary>
    /// Creates a new MenuDay object.
    /// </summary>
    /// <param name="dayNumer">The number of the menu day.</param>
    /// <param name="date">The date of the menu day.</param>
    /// <param name="meals">The list of meals for the menu day.</param>
    /// <returns>The created MenuDay object.</returns>
    public MenuDay CreateMenuDay(int dayNumer, DateTime date, List<Meal> meals)
    {
        string dateOfWeek = GetDayOfTheWeek(dayNumer);
        return MenuDay.Create(dateOfWeek, date, meals);
    }

    /// <summary>
    /// Gets the name of the day of the week.
    /// </summary>
    /// <param name="dayOfTheWeek">The number of the day of the week.</param>
    /// <returns>The name of the day of the week.</returns>
    private string GetDayOfTheWeek(int dayOfTheWeek)
    {
        var day = DateTime.Now.AddDays(dayOfTheWeek).DayOfWeek;
        var cultureInfo = new CultureInfo("pl-PL");
        var result = cultureInfo.DateTimeFormat.GetDayName(day);
        return result;
    }

    /// <summary>
    /// Validates if there are enough recipes to create a menu for the specified number of days and meal types.
    /// </summary>
    /// <param name="dayNumer">The number of days to create.</param>
    /// <param name="recipesCount">The number of recipes.</param>
    /// <param name="mealTypeCount">The number of meal types.</param>
    /// <returns>True if there are enough recipes for the menu, otherwise false.</returns>
    private bool ValidateIsEnoughRecipesForMenu(int dayNumer, int recipesCount, int mealTypeCount)
    {
        return dayNumer == (recipesCount * mealTypeCount);
    }

}