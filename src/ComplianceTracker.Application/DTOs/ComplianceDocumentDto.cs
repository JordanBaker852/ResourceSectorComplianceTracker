namespace ComplianceTracker.Application.DTOs;

public record ComplianceDocumentDto(
    Guid Id, 
    string Name, 
    string DocumentType, 
    string ComplianceStatus
);