namespace Menu.Domain.MenuAggregate.ValueObjects
{
    using global::Menu.Domain.Common.Models;
    public sealed class MenuId : AggregateRootId<Guid>
{

    private MenuId(Guid value) : base(value)
    {
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
}