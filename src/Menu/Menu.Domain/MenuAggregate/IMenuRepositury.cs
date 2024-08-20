namespace Menu.Domain.MenuAggregate
{   
    using global::Menu.Domain.MenuAggregate.ValueObjects;
    public interface IMenuRepositury
    {
        Task AddAsync(Menu menu);
        Task<Menu> GetByIdAsync(MenuId id);
        Task UpdateAsync(Menu menu);
    }
}