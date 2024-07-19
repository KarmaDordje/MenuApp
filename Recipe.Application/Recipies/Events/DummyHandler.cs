namespace Recipe.Application.Recipies.Events
{
    using MediatR;
    using Recipe.Domain.RecipeAggregate.Events;

    public class DummyHandler : INotificationHandler<RecipeCreated>
    {
        public Task Handle(RecipeCreated notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}