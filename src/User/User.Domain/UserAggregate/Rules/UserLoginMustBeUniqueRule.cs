namespace User.Domain.UserAggregate.Rules;

using global::User.Domain.Common.Models;
public class UserLoginMustBeUniqueRule : IBusinessRule
    {
        private readonly IUsersCounter _usersCounter;
        private readonly string _login;

        internal UserLoginMustBeUniqueRule(IUsersCounter usersCounter, string login)
        {
            _usersCounter = usersCounter;
            _login = login;
        }

        public bool IsBroken() => _usersCounter.CountUsersWithLogin(_login) > 0;

        public string Message => "User Login must be unique";
    }