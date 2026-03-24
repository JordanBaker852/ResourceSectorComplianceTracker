using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Events
{
    public class SiteCreatedEvent(Site site) : BaseEvent
    {
        public Site Site { get; } = site;
    }
}