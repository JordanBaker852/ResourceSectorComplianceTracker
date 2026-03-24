using ComplianceTracker.Domain.Enums;
using ComplianceTracker.Domain.Events;

namespace ComplianceTracker.Domain.Entites
{
    public class Site : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostCode { get; set; } = string.Empty;
        public uint ExpiryWarningDays { get; private set; } = 30;
        public State State { get; set; }

        private Site () {}

        public static Site Create(string name, string address, string postCode, State state, uint expiryWarningDays)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(address);
            ArgumentException.ThrowIfNullOrWhiteSpace(postCode);

            if (expiryWarningDays < 1)
            {
                throw new ArgumentException("Expiry warning threshold must be at least 1 day."); 
            }

            var site = new Site
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
                PostCode = postCode,
                State = state,
                ExpiryWarningDays = expiryWarningDays
            };

            site.AddDomainEvent(new SiteCreatedEvent(site));

            return site;
        }
    }
}