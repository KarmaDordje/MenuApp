using FluentValidation;

using Recipe.Application.Ingredients.Commands.AddIngredient;
using Recipe.Application.Recipes.Commands.CreateRecipe;

namespace Recipe.Application.Common.Behavior
{
    public class CreateRecipeCommandValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}