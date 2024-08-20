namespace Recipe.Application.Recipes.Queries.GetRecipiesList;
using FluentValidation;
    public class GetRicipiesListQueryValidator : AbstractValidator<GetRecipiesListQuery>
    {
        public GetRicipiesListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }