using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Application.DTOs;

public record WorkerDetailsDto(
    Guid Id, 
    string FullName, 
    SiteDto Site, 
    IEnumerable<ComplianceDocumentDto> Documents
); 