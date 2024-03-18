namespace Recipe.Domain.ValueObjects
{
    public class Measurement
    {
       public decimal Quantity { get; set; }
        public QuantityType Name { get; set; }

        public Measurement(decimal quantity, QuantityType name)
        {
            this.Quantity = quantity;
            Name = name;
        }
    }
}