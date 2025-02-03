namespace Account.Application.AccountRegistrations.RegisterNewAccount;

using Configuration.Commands;
using Domain.AccountRegistrationAggregate;

using ErrorOr;

internal class RegisterNewAccountCommandHandler : ICommandHandler<RegisterNewAccountCommand, ErrorOr<Guid>>
{
    private readonly IAccountRegistrationsRepository _accountRegistrationsRepository;
    private readonly IAccountsCounter _accountsCounter;

    public RegisterNewAccountCommandHandler(
        IAccountRegistrationsRepository repository,
        IAccountsCounter accountsCounter
    )
    {
        this._accountRegistrationsRepository = repository;
        this._accountsCounter = accountsCounter;
    }

    public Task<ErrorOr<Guid>> Handle(RegisterNewAccountCommand command, CancellationToken cancellationToken)
    {   
        var password = PasswordManager.HashPassword(command.Password);
        throw new NotImplementedException();
    }
}