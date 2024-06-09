namespace Recipe.Application.Recipes.Commands.AddIngredinetCommandValidator
{
    using FluentValidation;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    public class AddIngredientCommandValidator : AbstractValidator<AddIngredientCommand>
    {
        public AddIngredientCommandValidator()
        {
            RuleFor(x => x.IngredientName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.RecipeId)
                .NotEmpty();
            RuleFor(x => x.Quantity)
                .GreaterThan(0);
        }
    }
}