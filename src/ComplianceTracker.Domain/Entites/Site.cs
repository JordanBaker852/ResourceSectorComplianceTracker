using ComplianceTracker.Domain.Entites.ValueObjects;
using ComplianceTracker.Domain.Enums;
using ComplianceTracker.Domain.Events;

namespace ComplianceTracker.Domain.Entites;

public class Site : BaseAuditableEntity
{
    public string Name { get; private set; } = string.Empty;
    public Address Address { get; private set; } = null!;
    private Site () {}

    public static Site Create(string name, string street, string suburb, State state, string postCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        ArgumentException.ThrowIfNullOrWhiteSpace(suburb);
        ArgumentException.ThrowIfNullOrWhiteSpace(postCode);

        var site = new Site
        {
            Id = Guid.NewGuid(),
            Address = Address.Create(street, suburb, state, postCode)
        };

        site.AddDomainEvent(new SiteCreatedEvent(site));

        return site;
    }
}