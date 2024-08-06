namespace Menu.Domain.MenuAggregate
{
    using global::Menu.Domain.Common.Models;
    public class UserId : ValueObject
    {
        public Guid Value { get; private set; }

        public UserId(Guid value)
        {
            Value = value;
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