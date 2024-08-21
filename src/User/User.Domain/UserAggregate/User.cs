namespace User.Domain.UserAggregate;

using global::User.Domain.Common.Models;
using global::User.Domain.UserAggregate.Rules;
using global::User.Domain.ValueObjects;

public sealed class User : AggregateRoot<UserId, Guid>
{   
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Login { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserRegistrationStatus RegistrationStatus { get; private set; }
    public DateTime RegistrationDate { get; private set; }
    public DateTime ConfirmationDate { get; private set; }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string login,
        string email,
        string passwod,
        DateTime registrationDate,
        IUsersCounter usersCounter)
        : base(userId)
    {       
            this.CheckRule(new UserLoginMustBeUniqueRule(usersCounter, login));
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Email = email;
            Password = passwod;
            RegistrationDate = registrationDate;
            RegistrationStatus = UserRegistrationStatus.WaitingForConfirmation;
    }

    public static User Create(
        string firstName,
        string lastName,
        string login,
        string email,
        string password,
        IUsersCounter usersCounter,
        string confirmationLink)
    {   
        
        var user = new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            login,
            email,
            password,
            DateTime.UtcNow,
            usersCounter);
        return user;
    }

    #pragma warning disable CS8618
    private User()
    {
    }
#pragma warning restore CS8618

}