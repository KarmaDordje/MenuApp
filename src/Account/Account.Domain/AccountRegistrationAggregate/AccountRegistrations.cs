using Account.Domain.AccountRegistrationAggregate.ValueObjects;
using Account.Domain.Common.Models;

namespace Account.Domain.AccountRegistrationAggregate;

public sealed class AccountRegistrations : AggregateRoot<AccountRegistrationId, Guid>
{
    public AccountRegistrationId Id { get; private set; }

    public string Login { get; }

    public string Password { get; }

    public string Email { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string Name;

    public DateTime RegistrationDate { get; }

    public UserRegistrationStatus Status { get; }

    public DateTime? ConfirmedDate { get; }

    private AccountRegistrations()
    {
        // Only EF.
    }
    
    public static AccountRegistrations RegisterNewUser(
        string login,
        string password,
        string email,
        string firstName,
        string lastName,
        IAccountsCounter usersCounter,
        string confirmLink)
    {
        return new AccountRegistrations(login, password, email, firstName, lastName, usersCounter, confirmLink);
    }
    
    private AccountRegistrations(
        string login,
        string password,
        string email,
        string firstName,
        string lastName,
        IAccountsCounter usersCounter,
        string confirmLink)
    {
        //this.CheckRule(new UserLoginMustBeUniqueRule(usersCounter, login));

        this.Id = AccountRegistrationId.CreateUnique();
        this.Login = login;
        this.Password = password;
        this.Email = email;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Name = $"{firstName} {lastName}";
        this.RegistrationDate = DateTime.UtcNow;
        this.Status = UserRegistrationStatus.WaitingForConfirmation;

        // this.AddDomainEvent(new NewUserRegisteredDomainEvent(
        //     this.Id,
        //     _login,
        //     _email,
        //     _firstName,
        //     _lastName,
        //     _name,
        //     _registerDate,
        //     confirmLink));
    }

}