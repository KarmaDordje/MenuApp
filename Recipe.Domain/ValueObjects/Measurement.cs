using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class Measurement : ValueObject
    {
        public decimal Quantity { get; set; }
        public QuantityType Name { get; set; }

        public Measurement(decimal quantity, QuantityType name)
        {
            this.Quantity = quantity;
            Name = name;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}