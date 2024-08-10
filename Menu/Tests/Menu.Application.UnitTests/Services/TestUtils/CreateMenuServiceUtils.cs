namespace Menu.Application.UnitTests.Services.TestUtils;

using global::Menu.Domain.MenuAggregate;
using global::Menu.Domain.MenuAggregate.Entities;
using global::Menu.Application.UnitTests.TestUtils.Constants;

public static class CreateMenuServiceUtils
    {
        public static List<Meal> CreateMeal(int count)
        {
            return Enumerable.Range(0, count).Select(_ => Domain.MenuAggregate.Entities.Meal.Create(
                $"{Constants.Meal.RecipeName} {count}",
                Constants.Meal.RecipeDescription,
                Constants.Meal.RecipeImageUrl,
                Constants.Meal.MenyType,
                UserId.Create(Constants.User.UserId)))
                .ToList();
        }

        public static List<MenuDay> CreateMenuDay(int count)
        {
           return Enumerable.Range(0, count).Select(_ => MenuDay.Create(
                Constants.ManuDay.DayOfTheWeek ?? "Monday",
                DateTime.Now,
                CreateMeal(count)))
                .ToList();
        }
    }
