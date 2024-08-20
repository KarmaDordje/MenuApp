namespace User.Domain.UserAggregate;

using global::User.Domain.Common.Models;
using global::User.Domain.ValueObjects;

public sealed class User : AggregateRoot<UserId, Guid>
{   

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string email,
        string passwod)
        : base(userId)
    {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = passwod;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        var user = new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password);
        return user;
    }

}