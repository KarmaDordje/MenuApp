using Recipe.Domain.Common.Models;
using Recipe.Domain.Entities;

namespace Recipe.Domain.RecipeAggregate.Events;

    public record RecipeCreated(RecipeAggregate.Recipe Recipe) : IDomainEvent;