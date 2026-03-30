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

    public async Task DeleteAsync(Worker worker, CancellationToken ct = default)
    {
        context.Workers.Update(worker);
        await context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Worker>> GetAllActiveAsync(CancellationToken ct = default)
    {
        return await context.Workers.Where(x => x.IsActive)
            .Include(x => x.Site)
            .AsNoTracking()
            .ToListAsync(ct);
    }

    public async Task<Worker?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
       return await context.Workers
            .Include(x => x.Site)
            .Include(x => x.Documents)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
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