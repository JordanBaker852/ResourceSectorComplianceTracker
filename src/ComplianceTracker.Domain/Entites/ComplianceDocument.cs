using ComplianceTracker.Domain.Enums;
using ComplianceTracker.Domain.Events;

namespace ComplianceTracker.Domain.Entites
{
    public class ComplianceDocument : BaseAuditableEntity
    {
        public Guid WorkerId { get; private set; }
        public Worker Worker { get; private set; } = null!;
        public string Name { get; set; } = string.Empty;
        public DocumentType DocumentType { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public DocumentStatus GetStatus(uint siteExpiringThresholdDays)
        {
            if (ExpiryDate < DateTime.UtcNow.Date)
                return DocumentStatus.Expired;

            if (ExpiryDate <= DateTime.UtcNow.Date.AddDays(siteExpiringThresholdDays))
                return DocumentStatus.ExpiringSoon;

            return DocumentStatus.Valid;
        }

        private ComplianceDocument() {}

        public static ComplianceDocument Create(Guid workerId, string name, DocumentType documentType, DateTime issueDate, DateTime expiryDate)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            
            if (expiryDate <= issueDate)
            {
                throw new ArgumentException("Expiry date must be after the date issued.", nameof(expiryDate));
            }

            var document = new ComplianceDocument
            {
                Id = Guid.NewGuid(),
                WorkerId = workerId,
                Name = name,
                DocumentType = documentType,
                IssueDate = issueDate,
                ExpiryDate = expiryDate
            };

            document.AddDomainEvent(new DocumentUploadedEvent(document));

            return document;
        }
    }
}