namespace Recipe.Application.Recipes.Commands.DeleteIngredient
{
    using FluentValidation;
    using Recipe.Application.Recipes.Commands.CreateRecipe;
    public class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
    {
        public DeleteIngredientCommandValidator()
        {
            RuleFor(x => x.RecipeId)
                .NotEmpty();
            RuleFor(x => x.IngredientId)
                .NotEmpty();
            RuleFor(x => x.RecipeSectionId)
                .NotEmpty();
        }
    }
}