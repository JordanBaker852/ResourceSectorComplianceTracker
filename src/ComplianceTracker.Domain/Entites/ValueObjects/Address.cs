using ComplianceTracker.Domain.Enums;

namespace ComplianceTracker.Domain.Entites.ValueObjects;

public record Address
{
    public string Street { get; init; } = string.Empty;
    public string Suburb { get; init; } = string.Empty;
    public State State { get; init; }
    public string PostCode { get; init; } = string.Empty;
    public string Country { get; init; } = "Australia";

    private Address() {}

    public static Address Create(string street, string suburb, State state, string postCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(street);
        ArgumentException.ThrowIfNullOrWhiteSpace(suburb);
        ArgumentException.ThrowIfNullOrWhiteSpace(postCode);

        return new Address
        {
            Street = street,
            Suburb = suburb,
            State = state,
            PostCode = postCode
        };
    }
}