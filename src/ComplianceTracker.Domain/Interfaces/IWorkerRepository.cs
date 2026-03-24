using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Interfaces
{
    public interface IWorkerRepository
    {
        Task<Worker?> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<Worker?> GetWithDocumentsByIdAsync(Guid id, CancellationToken ct = default);
        Task<IQueryable<Worker>> GetBySiteIdAsync(Guid siteId, CancellationToken ct = default);
        Task<IQueryable<Worker>> GetAllActiveAsync(CancellationToken ct = default);
        Task AddAsync(CancellationToken ct = default);
        void Update();
        Task DeleteAsync(CancellationToken ct = default);
    }
}