using ErrorOr;

namespace Recipe.Domain.Common.Errors
{
    public static class RecipeErrors
    {
        public static class RecipeStep
        {
           public static Error RecipeNotFound => Error.NotFound("RecipeNotFound", "RecipeNotFound not found");
        }
    }
}