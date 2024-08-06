namespace Menu.Application.Services;

using global::Menu.Domain.MenuAggregate;
using global::Menu.Domain.MenuAggregate.Entities;
using global::Menu.Domain.Sercives;

public class CreateMenuService : ICreateMenuService
{
    public Task<Meal> CreateMealAsync(string recipeName, string recipeDescription, string recipeImageUrl, string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.MenuAggregate.Menu> CreateMenuAsync(string name, string description, List<UserId> users, List<MenuDay> menuDays)
    {
        throw new NotImplementedException();
    }

    public Task<MenuDay> CreateMenuDayAsync(string dateOfWeek, DateTime date, List<Meal> meals)
    {
        throw new NotImplementedException();
    }

}