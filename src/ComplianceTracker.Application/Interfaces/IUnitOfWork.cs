namespace ComplianceTracker.Application.Interfaces;

public interface IUnitOfWork
{
    IWorkerRepository Workers { get; }
    IDocumentRepository Documents { get; }
}