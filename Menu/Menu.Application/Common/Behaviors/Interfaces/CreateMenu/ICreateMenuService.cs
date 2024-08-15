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
        ErrorOr<Menu> GenerateMenu(
            string userId,
            DateTime startDate,
            int daysCount,
            List<MealCategory> mealCategories,
            List<RecipeDTO> recipes);
    }
