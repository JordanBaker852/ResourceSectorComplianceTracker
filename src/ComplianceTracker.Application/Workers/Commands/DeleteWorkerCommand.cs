using ComplianceTracker.Application.Interfaces;
using MediatR;

namespace ComplianceTracker.Application.Workers.Commands;

public record DeleteWorkerCommand(
    Guid Id
) : IRequest;

public class DeleteWorkerCommandHandler(IWorkerRepository repo) : IRequestHandler<DeleteWorkerCommand>
{
    public async Task Handle(DeleteWorkerCommand request, CancellationToken ct)
    {
        var worker = await repo.GetByIdAsync(request.Id, ct);

        if (worker == null)
        {
            throw new KeyNotFoundException($"Worker ID: {request.Id} not found in the system");
        }

        worker.Deactivate();

        await repo.DeleteAsync(worker, ct);
    }
}