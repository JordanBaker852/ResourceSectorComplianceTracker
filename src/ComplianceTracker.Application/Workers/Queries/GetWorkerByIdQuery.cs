using ComplianceTracker.Application.DTOs;
using ComplianceTracker.Application.Interfaces;
using MediatR;

namespace ComplianceTracker.Application.Workers.Queries;

public record GetWorkerByIdQuery(Guid Id) : IRequest<WorkerDetailsDto>;

public class GetWorkerByIdQueryHandler(IWorkerRepository repo) : IRequestHandler<GetWorkerByIdQuery, WorkerDetailsDto>
{
    public async Task<WorkerDetailsDto> Handle(GetWorkerByIdQuery request, CancellationToken ct)
    {
        var worker = await repo.GetByIdAsync(request.Id, ct);

        if (worker == null)
        {
            throw new KeyNotFoundException($"Worker ID: {request.Id} not found in the system");
        }

        return new WorkerDetailsDto
        (
            Id: worker.Id,
            FullName: worker.FullName,
            Site: new SiteDto
            (
                Id: worker.Site.Id, 
                Name: worker.Site.Name
            ),
            Documents: worker.Documents.Select(x => new ComplianceDocumentDto
            (
                Id: x.Id,
                Name: x.Name,
                DocumentType: x.DocumentType.ToString(),
                ComplianceStatus: x.GetStatus(30).ToString()
            ))
        );
    }
}