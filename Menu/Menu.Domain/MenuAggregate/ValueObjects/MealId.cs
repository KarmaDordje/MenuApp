namespace Menu.Domain.MenuAggregate.ValueObjects
{
    using global::Menu.Domain.Common.Models;
    public class MealId : ValueObject
    {
        public Guid Value { get; private set; }

        public MealId(Guid value)
        {
            Value = value;
        }

        public static MealId CreateUnique()
        {
            return new MealId(Guid.NewGuid());
        }

        public static MealId Create(Guid value)
        {
            return new MealId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}