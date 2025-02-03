namespace Account.Domain.AccountRegistrationAggregate.ValueObjects;
using Account.Domain.Common.Models;
public class AccountRegistrationId: AggregateRootId<Guid>
{
    private AccountRegistrationId(Guid value) : base(value)
    {
    }

    public static AccountRegistrationId CreateUnique()
    {
        return new AccountRegistrationId(Guid.NewGuid());
    }

    public static AccountRegistrationId Create(Guid value)
    {
        return new AccountRegistrationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}