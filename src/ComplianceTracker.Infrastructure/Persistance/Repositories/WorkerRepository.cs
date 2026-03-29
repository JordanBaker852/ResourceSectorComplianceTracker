using ComplianceTracker.Application.Interfaces;
using ComplianceTracker.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ComplianceTracker.Infrastructure.Persistance.Repositories;

public class WorkerRepository(ApplicationDbContext context) : IWorkerRepository
{
    public async Task AddAsync(Worker worker, CancellationToken ct = default)
    {
        context.Workers.Add(worker);
        await context.SaveChangesAsync(ct);
    }

    public Task DeleteAsync(CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Worker>> GetAllActiveAsync(CancellationToken ct = default)
    {
        return await context.Workers.Where(x => x.IsActive)
            .Include(x => x.Site)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public Task<Worker?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Worker>> GetBySiteIdAsync(Guid siteId, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public Task<Worker?> GetWithDocumentsByIdAsync(Guid id, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }
}