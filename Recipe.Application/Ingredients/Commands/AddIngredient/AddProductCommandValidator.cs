using FluentValidation;

using Recipe.Application.Ingredients.Commands.AddIngredient;

namespace Recipe.Application.Common.Behavior
{
    public class AddIngredientCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddIngredientCommandValidator()
        {
            RuleFor(x => x.IngredientName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Quantity)
                .GreaterThan(0);
        }
    }
}