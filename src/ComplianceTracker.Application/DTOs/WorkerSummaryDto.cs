namespace ComplianceTracker.Application.DTOs;
public record WorkerSummaryDto(
    Guid Id, 
    string FullName,
    SiteDto Site, 
    string ComplianceStatus,
    uint TotalDocuments, 
    uint TotalExpiringDocuments,
    uint TotalExpiredDocuments
);