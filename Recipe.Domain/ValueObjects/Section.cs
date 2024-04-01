using Recipe.Domain.Common.Models;

namespace Recipe.Domain.ValueObjects
{
    public class Section : ValueObject
    {
        public string Name { get; set; }

        public Section(string name, string description)
        {
            Name = name;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}