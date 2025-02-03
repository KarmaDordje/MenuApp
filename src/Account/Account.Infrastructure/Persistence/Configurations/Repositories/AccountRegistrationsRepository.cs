using Account.Domain.AccountRegistrationAggregate;

namespace Account.Infrastructure.Persistance.Configurations.Repositories;

public class AccountRegistrationsRepository : IAccountRegistrationsRepository
{
    public Task AddAsync(AccountRegistrations userRegistrations)
    {
        throw new NotImplementedException();
    }

    public Task<AccountRegistrations> GetByIdAsync(AccountRegistrations userRegistrationsId)
    {
        throw new NotImplementedException();
    }
}