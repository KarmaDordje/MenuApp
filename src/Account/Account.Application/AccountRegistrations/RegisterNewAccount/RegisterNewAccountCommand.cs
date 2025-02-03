namespace Account.Application.AccountRegistrations.RegisterNewAccount;

using Account.Application.Contracts;
using ErrorOr;
public class RegisterNewAccountCommand : CommandBase<ErrorOr<Guid>>
{
    
    public string Login { get; }

    public string Password { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string ConfirmLink { get; }
}