namespace Menu.Domain.Sercives;

    using Menu.Domain.MenuAggregate;
    using Menu.Domain.MenuAggregate.Entities;
    public interface ICreateMenuService
    {
        Menu CreateMenuAsync(string name, string description, List<UserId> users, List<MenuDay> menuDays);
        Meal CreateMealAsync(string recipeName, string recipeDescription, string recipeImageUrl, string userId);
        MenuDay CreateMenuDayAsync(string dateOfWeek, DateTime date, List<Meal> meals);
    }
