using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Application.Interfaces;

public interface IDocumentRepository
{
    Task<ComplianceDocument?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IQueryable<ComplianceDocument>> GetAllByWorkerId(Guid workerId, CancellationToken ct = default);
    Task<IQueryable<ComplianceDocument>> GetAllExpiringByDaysAsync(int numberOfDays, CancellationToken ct = default);
    Task<IQueryable<ComplianceDocument>> GetAllExpiredAsync(CancellationToken ct = default);
    Task AddAsync(CancellationToken ct = default);
    void Update();
    Task DeleteAsync(CancellationToken ct = default); 
}