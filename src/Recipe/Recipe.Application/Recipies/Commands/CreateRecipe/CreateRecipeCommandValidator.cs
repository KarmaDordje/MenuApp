namespace Recipe.Application.Common.Behavior
{
    using FluentValidation;
    using Recipe.Application.Ingredients.Commands.AddIngredient;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}