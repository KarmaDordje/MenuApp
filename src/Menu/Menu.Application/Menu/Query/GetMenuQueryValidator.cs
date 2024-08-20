namespace Menu.Application.Menu.Query
{
    using FluentValidation;

    public class GetMenuQueryValidator : AbstractValidator<GetMenuQuery>
    {
        public GetMenuQueryValidator()
        {
            RuleFor(x => x.MenuId).NotEmpty();
        }
    }
    
}