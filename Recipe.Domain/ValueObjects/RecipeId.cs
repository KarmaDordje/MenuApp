using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects;
public sealed class RecipeId : ValueObject
{
    public Guid Value { get; private set; }

    private RecipeId(Guid value)
    {
        Value = value;
    }

    public static RecipeId CreateUnique()
    {
        return new RecipeId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}