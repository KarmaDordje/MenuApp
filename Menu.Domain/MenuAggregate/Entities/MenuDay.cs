namespace Menu.Domain.MenuAggregate.Entities
{
    using global::Menu.Domain.Common.Models;
    using global::Menu.Domain.MenuAggregate.ValueObjects;
    public sealed class MenuDay : Entity<MenuDayId>
    {
        private readonly List<Meal> _meals = new List<Meal>();

        public MenuId MenuId { get; private set; }
        public string DayOfWeek { get; private set; }
        public DateTime Date { get; private set; }
        public IReadOnlyList<Meal> Meals => _meals.AsReadOnly();

        private MenuDay(
            MenuDayId menuDayId,
            MenuId menuId,
            string dateOfWeek,
            DateTime date,
            List<Meal> meals)
            : base(menuDayId)
        {
            MenuId = menuId;
            DayOfWeek = dateOfWeek;
            Date = date;
            _meals = meals;
        }

        public static MenuDay Create(
            MenuId menuId,
            string dateOfWeek,
            DateTime date,
            List<Meal> meals)
        {
            var menuDay = new MenuDay(
                MenuDayId.CreateUnique(),
                menuId,
                dateOfWeek,
                date,
                meals ?? new ());
            return menuDay;
        }

        public void AddMeal(Meal meal)
        {
            _meals.Add(meal);
        }

        #pragma warning disable CS8618
        private MenuDay()
        {
        }
        #pragma warning restore CS8618
    }
}