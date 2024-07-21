namespace Menu.Infrastructure.Repositories
{
    using Menu.Domain.MenuAggregate;
    using Menu.Infrastructure.Persistance;
    using Microsoft.EntityFrameworkCore;


    public class MenuRepository : IMenuRepositury
    {
        private readonly MenuDbContext _dbContext;
        public MenuRepository(MenuDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Menu menu)
        {
            await _dbContext.Menus.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Menu> GetByIdAsync(MenuId id)
        {
            return await _dbContext.Menus.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateAsync(Menu menu)
        {
            _dbContext.Menus.Update(menu);
            await _dbContext.SaveChangesAsync();
        }
    }
}