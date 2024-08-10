namespace Menu.Application.Common.Intefaces.CreareMenu;

using System;
using System.Collections.Generic;

using ErrorOr;
using global::Menu.Contracts.Menu;
using global::Menu.Domain.Common.Shared;
using global::Menu.Domain.MenuAggregate;
using global::Menu.Domain.MenuAggregate.Entities;
    public interface ICreateMenuService
    {
        ErrorOr<Menu> CreateMenu(
            string name,
            string description,
            string userId,
            DateTime startDate,
            int daysCount,
            List<MealCategory> mealCategories,
            List<MenuDay> menuDays,
            List<RecipeDTO> recipes);
        Meal CreateMeal(string recipeName, string recipeDescription, string recipeImageUrl, MealCategory mealType, string userId);
        MenuDay CreateMenuDay(int dayNumer, DateTime date, List<Meal> meals);

        List<MenuDay> CreateMenuDayList(int dayNumer, DateTime startFrom, DateTime date, List<Meal> meals);
    }
