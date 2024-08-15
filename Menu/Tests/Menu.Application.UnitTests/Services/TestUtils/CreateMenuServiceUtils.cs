namespace Menu.Application.UnitTests.Services.TestUtils;

using global::Menu.Domain.MenuAggregate;
using global::Menu.Domain.MenuAggregate.Entities;
using global::Menu.Application.UnitTests.TestUtils.Constants;
using global::Menu.Contracts.Menu;
using Bogus;
using global::Menu.Domain.Common.Shared;


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

        public static List<RecipeDTO> CreateRecipies(int count)
        {
            var fakeRecipies = new Faker<RecipeDTO>()
                .RuleFor(r => r.RecipeName, f => f.Lorem.Word())
                .RuleFor(r => r.RecipeId, f => f.Random.Guid().ToString())
                .RuleFor(r => r.AvarageRating, f => f.Random.Decimal())
                .RuleFor(r => r.ImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(r => r.CreatedAt, f => f.Date.Past())
                .RuleFor(r => r.UserId, f => f.Random.Guid().ToString())
                .RuleFor(r => r.RecipeDescription, f => f.Lorem.Sentence())
                .RuleFor(r => r.Category, f => f.PickRandomWithout<MealCategory>(MealCategory.Unknown, MealCategory.Snack, MealCategory.Dinner, MealCategory.Dessert));
            
            return fakeRecipies.Generate(count);
        }
    }
