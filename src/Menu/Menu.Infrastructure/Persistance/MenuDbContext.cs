namespace Menu.Infrastructure.Persistance
{
    using Menu.Domain.MenuAggregate.ValueObjects;


    using Microsoft.EntityFrameworkCore;
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options)
            : base(options)
        {
        }
        public DbSet<Menu.Domain.MenuAggregate.Menu> Menus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MenuDbContext).Assembly);
        }
    }
}