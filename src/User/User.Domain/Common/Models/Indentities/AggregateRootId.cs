namespace User.Domain.Common.Models.Identities;

public abstract class AggregateRootId<TId> : EntityId<TId>
{
    protected AggregateRootId(TId value)
    : base(value)
    {
    }
}