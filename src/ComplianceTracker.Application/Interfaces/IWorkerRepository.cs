using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Application.Interfaces;

public interface IWorkerRepository
{
    Task<Worker?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Worker?> GetWithDocumentsByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Worker>> GetBySiteIdAsync(Guid siteId, CancellationToken ct = default);
    Task<IEnumerable<Worker>> GetAllActiveAsync(CancellationToken ct = default);
    Task AddAsync(Worker worker, CancellationToken ct = default);
    void Update();
    Task DeleteAsync(Worker worker, CancellationToken ct = default);
}