using ComplianceTracker.Domain.Events;

namespace ComplianceTracker.Domain.Entites;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }
    private readonly List<BaseEvent> _domainEvents = [];
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected void AddDomainEvent(BaseEvent domainEvent) => _domainEvents.Add(domainEvent);
    protected void ClearDomainEvents() => _domainEvents.Clear();
}