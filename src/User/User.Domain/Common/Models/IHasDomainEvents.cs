namespace User.Domain.Common.Models
{
    public interface IhasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
        public void ClearDomainEvents();
    }
}