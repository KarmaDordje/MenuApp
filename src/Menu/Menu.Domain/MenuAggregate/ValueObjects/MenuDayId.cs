namespace Menu.Domain.MenuAggregate.ValueObjects
{
    using System;
    using global::Menu.Domain.Common.Models;

    public class MenuDayId : ValueObject
    {
        public Guid Value { get; private set; }

        public MenuDayId(Guid value)
        {
            Value = value;
        }

        public static MenuDayId CreateUnique()
        {
            return new MenuDayId(Guid.NewGuid());
        }

        public static MenuDayId Create(Guid value)
        {
            return new MenuDayId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}