namespace Recipe.Application.UnitTests.TestUnits.Constants;

/// <summary>
/// Constants related to recipes.
/// </summary>
public static partial class Constants
{
    // Constants related to recipe properties
    public static class Recipe
    {
        /// <summary>
        /// Name of the recipe.
        /// </summary>
        public const string Name = "Recipe Name";

        /// <summary>
        /// Description of the recipe.
        /// </summary>
        public const string Description = "Recipe Description";

        /// <summary>
        /// User ID associated with the recipe.
        /// </summary>
        public const string UserId = "9be11a16-538d-41fa-a620-439a002e4baa";

        /// <summary>
        /// Average rating of the recipe.
        /// </summary>
        public const float AvarageRating = 4.5f;

        /// <summary>
        /// URL of the recipe image.
        /// </summary>
        public const string ImageUrl = "https://www.recipe.com/image.jpg";

        /// <summary>
        /// URL of the recipe video.
        /// </summary>
        public const string VideoUrl = "https://www.recipe.com/video.mp4";

        /// <summary>
        /// Creation date and time of the recipe.
        /// </summary>
        public const string CreatedAt = "2021-09-01T00:00:00Z";

        /// <summary>
        /// Last updated date and time of the recipe.
        /// </summary>
        public const string UpdatedAt = "2021-09-01T00:00:00Z";

        /// <summary>
        /// Steps of the recipe.
        /// </summary>
        public const string RecipeStep = "Recipe Step";

        /// <summary>
        /// Ingredients of the recipe.
        /// </summary>
        public const string Ingredient = "Ingredient";

        public static string IngredientNameFromIndex(int index)
            => $"{Ingredient} {index}";

        public static decimal IngredientQuantityFromIndex(int index)
            => index + 1;

        public static string RecipeStepNameFromIndex(int index)
            => $"{RecipeStep} {index}";

        public static int RecipeStepOrderFromIndex(int index)
            => index;
    }

}