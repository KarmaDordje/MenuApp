using Account.Domain.AccountRegistrationAggregate;
using Account.Domain.Common.Models;

namespace Account.Domain.Rules;

public class UserLoginMustBeUniqueRule : IBusinessRule
{
    private readonly IAccountsCounter _accountsCounter;
    private readonly string _login;

    internal UserLoginMustBeUniqueRule(IAccountsCounter accountsCounter, string login)
    {
        this._accountsCounter = accountsCounter;
        this._login = login;
    }

    public bool IsBroken() => _accountsCounter.CountUsersWithLogin(_login) > 0;

    public string Message => "User Login must be unique";
}