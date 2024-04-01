using ErrorOr;

namespace Recipe.Domain.Common.Errors
{
    public static class Ingredient
    {
        public static Error IngredientNameCannotBeEmpty => Error.Validation("Ingredient.IngredientName", "Ingredient name cannot be empty");
        public static Error IngredientNameTooLong => Error.Validation("IngredientNameTooLong", "Ingredient name is too long");
        public static Error QuantityMustBeGreaterThanZero => Error.Validation("Ingredient.QuantityMustBeGreaterThanZero", "Quantity must be greater than zero");
        public static Error IngredientNotFound => Error.NotFound("IngredientNotFound", "Ingredient not found");
        public static Error IngredientAlreadyExists => Error.Conflict("IngredientAlreadyExists", "Ingredient already exists");
    }
}