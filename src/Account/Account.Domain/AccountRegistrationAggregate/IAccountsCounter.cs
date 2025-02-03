namespace Account.Domain.AccountRegistrationAggregate;

public interface IAccountsCounter
{
    int CountUsersWithLogin(string login);
}