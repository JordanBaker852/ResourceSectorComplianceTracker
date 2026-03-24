using ComplianceTracker.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace ComplianceTracker.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Worker> Workers { get; set; }
}