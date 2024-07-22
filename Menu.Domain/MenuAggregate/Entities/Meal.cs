namespace Menu.Domain.MenuAggregate.Entities
{
    using global::Menu.Domain.Common.Models;
    using global::Menu.Domain.Common.Shared;
    using global::Menu.Domain.MenuAggregate.ValueObjects;

    public class Meal : Entity<MealId>
    {   
        public MenuId MenuId { get; private set; }
        public MenuDayId MenuDayId { get; private set; }
        public string RecipeName { get; private set; }
        public string RecipeDescription { get; private set; }
        public string RecipeImageUrl { get; private set; }
        public UserId UserId { get; private set; }
        public MealType MealType { get; private set; }

        private Meal(
            MenuId menuId,
            MenuDayId menuDayId,
            string recipeName,
            string recipeDescription,
            string recipeImageUrl,
            UserId userId)
            : base(MealId.CreateUnique())
        {   
            MenuId = menuId;
            MenuDayId = menuDayId;
            RecipeName = recipeName;
            RecipeDescription = recipeDescription;
            RecipeImageUrl = recipeImageUrl;
            UserId = userId;
        }

        public static Meal Create(
            MenuId menuId,
            MenuDayId menuDayId,
            string recipeName,
            string recipeDescription,
            string recipeImageUrl,
            UserId userId)
        {
            var meal = new Meal(
                menuId,
                menuDayId,
                recipeName,
                recipeDescription,
                recipeImageUrl,
                userId);
            return meal;
        }
    }
}