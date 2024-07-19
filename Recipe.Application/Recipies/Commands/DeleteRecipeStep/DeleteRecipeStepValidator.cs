namespace Recipe.Application.Recipes.Commands.DeleteRecipeStep
{
    using FluentValidation;
    public class DeleteRecipeStepValidator : AbstractValidator<DeleteRecipeStepCommand>
    {
        public DeleteRecipeStepValidator()
        {
            RuleFor(x => x.RecipeId)
                .NotEmpty();
            RuleFor(x => x.RecipeStepId)
                .NotEmpty();
        }
    }
}