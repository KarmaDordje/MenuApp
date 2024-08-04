namespace Menu.Domain.MenuAggregate
{
    using global::Menu.Domain.Common.Models;
    using global::Menu.Domain.MenuAggregate.Entities;
    using global::Menu.Domain.MenuAggregate.ValueObjects;

    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuDay> _menuDays = new List<MenuDay>();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public UserId UserId { get; private set; }
        public IReadOnlyList<MenuDay> MenuDays => _menuDays.AsReadOnly();
        private Menu(
            MenuId menuId,
            string name,
            string description,
            UserId userId,
            List<MenuDay> menuDays)
            : base(menuId)
        {
            Name = name;
            Description = description;
            UserId = userId;
            _menuDays = menuDays;
        }

        public static Menu Create(
            string name,
            string description,
            UserId userIds)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                name,
                description,
                userIds,
                new ());
            return menu;
        }

        // for EF Core purposes
#pragma warning disable CS8618
        public Menu()
        {
        }
#pragma warning restore CS8618
    }
}