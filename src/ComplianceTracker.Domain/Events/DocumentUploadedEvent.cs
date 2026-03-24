using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Events;

public class DocumentUploadedEvent(ComplianceDocument document) : BaseEvent
{
    public ComplianceDocument Document { get; } = document;
}