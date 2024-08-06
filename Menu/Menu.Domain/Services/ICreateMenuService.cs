namespace Menu.Domain.Sercives;

    using Menu.Domain.MenuAggregate;
    using Menu.Domain.MenuAggregate.Entities;
    public interface ICreateMenuService
    {
        Task<Domain.MenuAggregate.Menu> CreateMenuAsync(string name, string description, List<UserId> users, List<MenuDay> menuDays);
        Task<Meal> CreateMealAsync(string recipeName, string recipeDescription, string recipeImageUrl, string userId);
        Task<MenuDay> CreateMenuDayAsync(string dateOfWeek, DateTime date, List<Meal> meals);
    }
