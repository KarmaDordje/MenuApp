namespace Recipe.Domain.Common.Models;

public abstract class AggregateRoot<TId, TidType> : Entity<TId>
    where TId : AggregateRootId<TidType>
{
    protected AggregateRoot(TId id)
    {
        Id = id;
    }

    #pragma warning disable CS8618
    protected AggregateRoot()
    {
    }
    #pragma warning restore CS8618
}