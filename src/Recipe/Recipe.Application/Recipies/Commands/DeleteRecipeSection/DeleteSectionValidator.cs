namespace Recipe.Application.Recipes.Commands.DeleteRecipeSection
{
    using FluentValidation;
    using Recipe.Application.Recipes.Commands.DeleteIngredient;

    public class DeleteSectionValidator : AbstractValidator<DeleteRecipeSectionCommand>
    {
        public DeleteSectionValidator()
        {
            RuleFor(x => x.RecipeId)
                .NotEmpty();
            RuleFor(x => x.RecipeSectionId)
                .NotEmpty();
        }
    }
}