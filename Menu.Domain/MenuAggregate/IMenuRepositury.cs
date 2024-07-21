namespace Menu.Domain.MenuAggregate
{
    public interface IMenuRepositury
    {
        Task AddAsync(Menu menu);
        Task<Menu> GetByIdAsync(MenuId id);
        Task UpdateAsync(Menu menu);
    }
}