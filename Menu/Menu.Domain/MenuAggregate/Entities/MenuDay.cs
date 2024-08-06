namespace Menu.Domain.MenuAggregate.Entities
{
    using global::Menu.Domain.Common.Models;
    using global::Menu.Domain.MenuAggregate.ValueObjects;
    public sealed class MenuDay : Entity<MenuDayId>
    {
        private readonly List<Meal> _meals = new List<Meal>();

        public string DayOfWeek { get; private set; }
        public DateTime Date { get; private set; }
        public IReadOnlyList<Meal> Meals => _meals.AsReadOnly();

        private MenuDay(
            string dateOfWeek,
            DateTime date,
            List<Meal> meals,
            MenuDayId? id = null)
            : base(id ?? MenuDayId.CreateUnique())
        {
            DayOfWeek = dateOfWeek;
            Date = date;
            _meals = meals;
        }

        public static MenuDay Create(
            string dateOfWeek,
            DateTime date,
            List<Meal> meals)
        {
            var menuDay = new MenuDay(
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