using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

using Recipe.Domain.Common.Models;

namespace Recipe.Infrastructure.Persistence.Interceptors
{   
    
    public class PublishDomainEventsInterceptor : SaveChangesInterceptor
    {   
        private readonly IPublisher _mediator;
        public PublishDomainEventsInterceptor(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {   
            PublishDomainInvetns(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public async override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {   
            await PublishDomainInvetns(eventData.Context);
            return  await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private async Task PublishDomainInvetns(DbContext? dbContext)
        {
            if (dbContext is null)
            {
                return;
            }

            var entitiesWithDomainEvents = dbContext.ChangeTracker.Entries<IhasDomainEvents>()
                .Where(entry => entry.Entity.DomainEvents.Any())
                .Select(entry => entry.Entity)
                .ToList();

            var domainEvents = entitiesWithDomainEvents.SelectMany(entity => entity.DomainEvents).ToList();

            entitiesWithDomainEvents.ForEach(entity => entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
        }
    }
}