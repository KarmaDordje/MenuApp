namespace User.Infrastructure.Repositories;

using System.Threading.Tasks;
using User.Domain.UserAggregate;
using User.Domain.ValueObjects;

public class UserRepository : IUserRepository
{
    public Task AddAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(UserId userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
