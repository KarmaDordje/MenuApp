using MediatR;

using Recipe.Domain.RecipeAggregate.Events;

namespace Recipe.Application.Recipies.Events
{
    public class DummyHandler : INotificationHandler<RecipeCreated>
    {
        public Task Handle(RecipeCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}