namespace Recipe.Domain.Common.Models
{
    public abstract class AggregateRootId<Tid> : ValueObject
    {
       public abstract Tid Value { get; protected set; }
    }
}