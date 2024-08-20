namespace Menu.Application.Menu.Commands;
using FluentValidation;
public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
    }
}