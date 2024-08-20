namespace Recipe.Domain.ValueObjects
{
    using Recipe.Domain.Common.Models;

    public class Measurement : ValueObject
    {
         public Measurement(decimal quantity, QuantityType name)
        {
            this.Quantity = quantity;
            Name = name;
        }

         public decimal Quantity { get; set; }
         public QuantityType Name { get; set; }

         public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Quantity;
            yield return Name;
        }

        #pragma warning disable CS8618
         private Measurement()
        {
        }
        #pragma warning restore CS8618

    }

}