using ComplianceTracker.Application.DTOs;
using ComplianceTracker.Application.Interfaces;
using ComplianceTracker.Domain.Entites;
using FluentValidation;
using MediatR;

namespace ComplianceTracker.Application.Workers.Commands;

public record CreateWorkerCommand(
    string FirstName,
    string Surname,
    string JobTitle,
    Guid siteId
) : IRequest<WorkerCreatedDto>;

public class CreateWorkerCommandValidator : AbstractValidator<CreateWorkerCommand>
{
    public CreateWorkerCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.Surname).NotEmpty();
        RuleFor(x => x.JobTitle).NotEmpty();
    }
}

public class CreateWorkerCommandHandler(IWorkerRepository repo) : IRequestHandler<CreateWorkerCommand, WorkerCreatedDto>
{
    public async Task<WorkerCreatedDto> Handle(CreateWorkerCommand request, CancellationToken cancellationToken)
    {
        var worker = Worker.Create(request.FirstName, request.Surname, request.JobTitle, request.siteId);
        await repo.AddAsync(worker, cancellationToken);
        return new WorkerCreatedDto(worker.Id, worker.FullName, new SiteDto(worker.SiteId, ""));
    }
}