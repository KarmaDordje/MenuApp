using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class Step : ValueObject
    {
        public string Name { get; set; }
        public int Order { get; set; }

        public Step(string name, int order)
        {
            Name = name;
            Order = order;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}