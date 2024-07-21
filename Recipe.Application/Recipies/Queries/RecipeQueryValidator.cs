namespace Recipe.Application.Recipes.Queries
{
    using FluentValidation;
    public class RecipeQueryValidator : AbstractValidator<RecipeQuery>
    {
        public RecipeQueryValidator()
        {
            RuleFor(x => x.RecipeId)
                .NotEmpty();
        }
    }

}