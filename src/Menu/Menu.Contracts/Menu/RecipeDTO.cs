namespace Menu.Contracts.Menu;

    using global::Menu.Domain.Common.Shared;

    public class RecipeDTO
    {
         /// <summary>
        /// Gets or sets the name of the recipe.
        /// </summary>
        public string RecipeName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the recipe.
        /// </summary>
        public string RecipeId { get; set; }

        /// <summary>
        /// Gets or sets the average rating of the recipe.
        /// </summary>
        public decimal AvarageRating { get; set; }

        /// <summary>
        /// Gets or sets the URL of the recipe's image.
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the creation date of the recipe.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the ID of the user who created the recipe.
        /// </summary>
        public string UserId { get; set; }

        public string RecipeDescription { get; set; }

        /// <summary>
        /// Gets or sets the category of the recipe.
        /// </summary>
        public MealCategory Category { get; set; }
    }