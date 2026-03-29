namespace ComplianceTracker.Application.DTOs;

public record WorkerCreatedDto(
    Guid id,
    string FullName,
    SiteDto Site
);