namespace Recipe.Domain.RecipeAggregate.ValueObjects
{
    using System;
    using System.Collections.Generic;
    using global::Recipe.Domain.Common;
    using global::Recipe.Domain.Common.Models;
    using global::Recipe.Domain.ValueObjects;

    public class RecipeSectionId : ValueObject
    {
        public Guid Value { get; private set; }
        private RecipeSectionId(Guid value)
        {
            Value = value;
        }

        public static RecipeSectionId CreateUnique()
        {
            return new RecipeSectionId(Guid.NewGuid());
        }

        public static RecipeSectionId Create(Guid value)
        {
            return new RecipeSectionId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}