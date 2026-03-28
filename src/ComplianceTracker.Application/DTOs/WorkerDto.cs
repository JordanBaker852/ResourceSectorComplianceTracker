namespace ComplianceTracker.Application.DTOs;
public record WorkerDto(
    Guid Id, 
    string FullName,
    SiteDto Site, 
    string ComplianceStatus,
    uint TotalDocuments, 
    uint TotalExpiringDocuments,
    uint TotalExpiredDocuments
);