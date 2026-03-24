using ComplianceTracker.Application.Interfaces;
using ComplianceTracker.Domain.Entites;
using ComplianceTracker.Domain.Enums;
using MediatR;

namespace ComplianceTracker.Application.Workers.Queries;

public record GetWorkersQuery() : IRequest<IQueryable<WorkerDto>>;

public record WorkerDto(
    Guid Id, 
    string FullName, 
    Site Site, 
    ComplianceStatus ComplianceStatus, 
    uint TotalDocuments, 
    uint TotalExpiringDocuments,
    uint TotalExpiredDocuments
);

public class GetWorkersQueryHandler(IWorkerRepository repo) : IRequestHandler<GetWorkersQuery, IQueryable<WorkerDto>>
{
    public async Task<IQueryable<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken ct)
    {
        var workers = await repo.GetAllActiveAsync();

        return workers.Select(x => new WorkerDto(
        
            Id:                 x.Id,
            FullName:           x.FullName,
            Site:               x.Site,
            ComplianceStatus:   x.OverallComplianceStatus(30),
            TotalDocuments:     (uint)x.Documents.Count,
            TotalExpiringDocuments:  (uint)x.Documents.Count(d => d.GetStatus(30) == DocumentStatus.ExpiringSoon),
            TotalExpiredDocuments:   (uint)x.Documents.Count(d => d.GetStatus(30) == DocumentStatus.Expired)        
        ));
    }
}