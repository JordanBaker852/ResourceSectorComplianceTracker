using ComplianceTracker.Application.DTOs;
using ComplianceTracker.Application.Interfaces;
using ComplianceTracker.Domain.Enums;
using MediatR;

namespace ComplianceTracker.Application.Workers.Queries;

public record GetWorkersQuery() : IRequest<IEnumerable<WorkerDto>>;

public class GetWorkersQueryHandler(IWorkerRepository repo) : IRequestHandler<GetWorkersQuery, IEnumerable<WorkerDto>>
{
    public async Task<IEnumerable<WorkerDto>> Handle(GetWorkersQuery request, CancellationToken ct)
    {
        var workers = await repo.GetAllActiveAsync();

        return workers.Select(x => new WorkerDto(
        
            Id:                 x.Id,
            FullName:           x.FullName,
            Site:               new SiteDto(x.Site.Id, x.Site.Name),
            ComplianceStatus:   x.OverallComplianceStatus(30).ToString(),
            TotalDocuments:     (uint)x.Documents.Count,
            TotalExpiringDocuments:  (uint)x.Documents.Count(d => d.GetStatus(30) == DocumentStatus.ExpiringSoon),
            TotalExpiredDocuments:   (uint)x.Documents.Count(d => d.GetStatus(30) == DocumentStatus.Expired)        
        ));
    }
}