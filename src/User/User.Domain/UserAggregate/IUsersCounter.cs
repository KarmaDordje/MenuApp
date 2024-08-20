namespace User.Domain.UserAggregate;

    public interface IUsersCounter
    {
        int CountUsersWithLogin(string login);
    }