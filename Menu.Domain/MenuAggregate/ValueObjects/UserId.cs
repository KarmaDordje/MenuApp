namespace Menu.Domain.MenuAggregate
{
    using global::Menu.Domain.Common.Models;
    public sealed class UserId : AggregateRootId<Guid>
    {
        private UserId(Guid value) : base(value)
        {
        }

        public static UserId CreateUnique()
        {
            return new UserId(Guid.NewGuid());
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}