namespace Recipe.Domain.RecipeAggregate.Rules;

using global::Recipe.Domain.Common.Models;
using global::Recipe.Domain.RecipeAggregate.Entities;
using global::Recipe.Domain.RecipeAggregate.ValueObjects;

public class CantDeleteSectionIfNotFoundRule : IBusinessRule
    {
        private readonly RecipeSectionId _sectionId;
        private readonly List<RecipeSection> _recipeSections;

        public CantDeleteSectionIfNotFoundRule(RecipeSectionId sectionId, List<RecipeSection> recipeSections)
        {
            _sectionId = sectionId;
            _recipeSections = recipeSections;
        }

        public string Message => $"Section with id {_sectionId} not found.";

        public bool IsBroken() => _recipeSections.FirstOrDefault(x => x.Id == _sectionId) is null;
    }