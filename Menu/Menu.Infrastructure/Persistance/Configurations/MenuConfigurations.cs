namespace Menu.Infrastructure.Persistance.Configurations
{
    using Menu.Domain.MenuAggregate;
    using Menu.Domain.MenuAggregate.Entities;
    using Menu.Domain.MenuAggregate.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuDaysTable(builder);
        }

        private static void ConfigureMenuDaysTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuDays, menuDay =>
            {
                menuDay.ToTable("MenuDays");

                menuDay.WithOwner().HasForeignKey("MenuId");

                menuDay.HasKey("Id", "MenuId");

                menuDay.Property(x => x.Id)
                    .HasColumnName("MenuDayId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuDayId.Create(value));

                menuDay.Property(md => md.DayOfWeek)
                    .HasMaxLength(50);

                menuDay.Property(md => md.Date);

                menuDay.OwnsMany(md => md.Meals, meal =>
                {
                    meal.ToTable("Meals");

                    meal.WithOwner().HasForeignKey("MenuDayId", "MenuId");

                    meal.HasKey(nameof(Meal.Id), "MenuDayId", "MenuId");

                    meal.Property(x => x.Id)
                        .HasColumnName("MealId")
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => MealId.Create(value));

                    meal.Property(x => x.RecipeName)
                        .HasMaxLength(100);

                    meal.Property(x => x.RecipeDescription)
                        .HasMaxLength(500);

                    meal.Property(x => x.RecipeImageUrl)
                        .HasMaxLength(500);

                    meal.Property(x => x.UserId)
                        .HasConversion(
                            id => id.Value,
                            value => UserId.Create(value));
                });

                menuDay.Navigation(m => m.Meals).Metadata.SetField("_meals");
                menuDay.Navigation(m => m.Meals).UsePropertyAccessMode(PropertyAccessMode.Field);
            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuDays))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value)
                );

            builder.Property(x => x.Name)
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.UserId)
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));
        }
    }
}
