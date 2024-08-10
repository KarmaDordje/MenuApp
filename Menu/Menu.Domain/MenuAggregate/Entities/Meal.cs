namespace Menu.Domain.MenuAggregate.Entities
{
    using global::Menu.Domain.Common.Models;
    using global::Menu.Domain.Common.Shared;
    using global::Menu.Domain.MenuAggregate.ValueObjects;

    public class Meal : Entity<MealId>
    {
        public string RecipeName { get; private set; }
        public string RecipeDescription { get; private set; }
        public string RecipeImageUrl { get; private set; }
        public UserId UserId { get; private set; }
        public MealCategory MealType { get; private set; }

        private Meal(
            string recipeName,
            string recipeDescription,
            string recipeImageUrl,
            UserId userId,
            MealCategory mealType,
            MealId? id = null)
            : base(id ?? MealId.CreateUnique())
        {
            RecipeName = recipeName;
            RecipeDescription = recipeDescription;
            RecipeImageUrl = recipeImageUrl;
            MealType = mealType;
            UserId = userId;
        }

        public static Meal Create(
            string recipeName,
            string recipeDescription,
            string recipeImageUrl,
            MealCategory mealType,
            UserId userId)
        {
            var meal = new Meal(
                recipeName,
                recipeDescription,
                recipeImageUrl,
                userId,
                mealType);
            return meal;
        }

        #pragma warning disable CS8618
        private Meal()
        {
        }
        #pragma warning restore CS8618
    }

}