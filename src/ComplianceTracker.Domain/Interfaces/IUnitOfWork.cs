namespace ComplianceTracker.Domain.Interfaces;

public interface IUnitOfWork
{
    IWorkerRepository Workers { get; }
    IDocumentRepository Documents { get; }
}