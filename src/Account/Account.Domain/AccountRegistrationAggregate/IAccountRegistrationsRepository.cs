namespace Account.Domain.AccountRegistrationAggregate;

public interface IAccountRegistrationsRepository
{
    Task AddAsync(AccountRegistrations userRegistrations);

    Task<AccountRegistrations> GetByIdAsync(AccountRegistrations userRegistrationsId);
}