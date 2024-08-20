namespace User.Domain.Common.Models;

/// <summary>
/// Represents an abstract base class for entities in the domain model.
/// </summary>
/// <typeparam name="TId">The type of the entity's identifier.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>>, IhasDomainEvents
    where TId : notnull
{
    private readonly List<IDomainEvent> _domainEvents = new ();
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    public TId Id { get; protected set; }

    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    protected Entity(TId id)
    {
        Id = id;
    }

    /// <summary>
    /// Determines whether the current entity is equal to another entity.
    /// </summary>
    /// <param name="obj">The object to compare with the current entity.</param>
    /// <returns><c>true</c> if the current entity is equal to the other entity; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    /// <summary>
    /// Determines whether the current entity is equal to another entity.
    /// </summary>
    /// <param name="other">The entity to compare with the current entity.</param>
    /// <returns><c>true</c> if the current entity is equal to the other entity; otherwise, <c>false</c>.</returns>
    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    /// <summary>
    /// Determines whether two entities are equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns><c>true</c> if the two entities are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Determines whether two entities are not equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns><c>true</c> if the two entities are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Returns the hash code for the entity.
    /// </summary>
    /// <returns>The hash code for the entity.</returns>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Adds a domain event to the entity.
    /// </summary>
    /// <param name="domainEvent">The domain event to be added.</param>
    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

#pragma warning disable CS8618
    protected Entity()
    {
    }
    #pragma warning restore CS8618
}