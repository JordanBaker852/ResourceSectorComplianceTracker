using ComplianceTracker.Domain.Entites;
using ComplianceTracker.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace ComplianceTracker.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Worker> Workers { get; set; }
    public DbSet<ComplianceDocument> ComplianceDocuments { get; set; }
    public DbSet<Site> Sites { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Ignore<BaseEvent>();
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}