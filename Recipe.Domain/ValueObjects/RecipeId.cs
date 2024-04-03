using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects;
public sealed class RecipeId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private RecipeId(Guid value)
    {
        Value = value;
    }

    public static RecipeId CreateUnique()
    {
        return new RecipeId(Guid.NewGuid());
    }

    public static RecipeId Create(Guid value)
    {
        return new RecipeId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}