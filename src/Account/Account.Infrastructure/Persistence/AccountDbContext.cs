using Account.Domain.AccountRegistrationAggregate;

using Microsoft.EntityFrameworkCore;

namespace Account.Infrastructure.Persistence;

public class AccountDbContext : DbContext
{
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options) { }
}