namespace User.Domain.UserAggregate;
using global::User.Domain.ValueObjects;
    public interface IUserRepository
    {
        Task<User> GetAsync(UserId userId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }