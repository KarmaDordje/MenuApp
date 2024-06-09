using Recipe.Domain.Common.Models;


namespace Recipe.Domain.RecipeAggregate.Events;

    public record RecipeCreated(RecipeAggregate.Recipe Recipe) : IDomainEvent;