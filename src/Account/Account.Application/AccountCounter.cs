using Account.Domain.AccountRegistrationAggregate;
using Dapper;
using SharedCore.Data;

namespace Account.Application;

public class AccountCounter : IAccountsCounter
{
    
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public AccountCounter(ISqlConnectionFactory sqlConnectionFactory)
    {
        this._sqlConnectionFactory = sqlConnectionFactory;
    }
    public int CountUsersWithLogin(string login)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        const string sql = """
                           SELECT COUNT(*) 
                           FROM [registrations].[v_UserRegistrations] AS [UserRegistration]
                           WHERE [UserRegistration].[Login] = @Login
                           """;
        return connection.QuerySingle<int>(
            sql,
            new
            {
                login
            });
    }
}