namespace User.Application.User.Commands;

using Dapper;
using global::User.Domain.UserAggregate;

using SharedCore.Data;
public class UsersCounter : IUsersCounter
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UsersCounter(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public int CountUsersWithLogin(string login)
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();

            const string sql = """
                                SELECT COUNT(*) 
                                FROM "User" 
                                WHERE  "Login" = @Login;
                                """;
            return connection.QuerySingle<int>(
                sql,
                new
                {
                    login
                });
        }
    }