using FluentValidation;

namespace Account.Application.AccountRegistrations.RegisterNewAccount;

public class RegisterNewAccountValidator : AbstractValidator<RegisterNewAccountCommand>
{
    public RegisterNewAccountValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
    }
}