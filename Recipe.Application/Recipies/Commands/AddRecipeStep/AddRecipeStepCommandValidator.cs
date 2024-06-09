namespace Recipe.Application.Recipes.Commands.AddRecipeStep
{
    using FluentValidation;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    public class AddRecipeStepCommandValidator : AbstractValidator<AddRecipeStepCommand>
    {
        public AddRecipeStepCommandValidator()
        {
            RuleFor(x => x.RecipeId)
                .NotEmpty();
            RuleFor(x => x.StepNumber)
                .NotEmpty();
        }
    }
}