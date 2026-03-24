using ComplianceTracker.Domain.Enums;
using ComplianceTracker.Domain.Events;

namespace ComplianceTracker.Domain.Entites
{
    public class Worker : BaseAuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public Guid SiteId { get; private set; }
        public Site Site { get; private set; } = null!;
        public string FullName => $"{FirstName} {Surname}";

        private readonly List<ComplianceDocument> _documents = [];
        public IReadOnlyCollection<ComplianceDocument> Documents => _documents.AsReadOnly();

        public ComplianceStatus OverallComplianceStatus(uint siteExpiringThresholdDays)
        {
            if (_documents.Any(x => x.GetStatus(siteExpiringThresholdDays) == DocumentStatus.Expired))
                return ComplianceStatus.NonCompliant;
            
            if (_documents.Any(x => x.GetStatus(siteExpiringThresholdDays) == DocumentStatus.ExpiringSoon))
                return ComplianceStatus.ExpiringSoon;

            return ComplianceStatus.Compliant;
        }

        private Worker() {}

        public static Worker Create(string firstName, string surname, string jobTitle)
        {
            var worker = new Worker
            {
                Id = Guid.NewGuid(),
                FirstName = firstName,
                Surname = surname,
                JobTitle = jobTitle
            };

            worker.AddDomainEvent(new WorkerCreatedEvent(worker));

            return worker;
        }
    }
}