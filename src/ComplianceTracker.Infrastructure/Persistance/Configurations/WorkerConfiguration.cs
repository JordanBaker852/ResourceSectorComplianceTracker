using ComplianceTracker.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplianceTracker.Infrastructure.Persistance.Configurations;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasKey(x =>x.Id);
        
        builder.Property(x => x.FirstName).HasMaxLength(30).IsRequired();
        builder.Property(x => x.Surname).HasMaxLength(30).IsRequired();
        builder.Property(x => x.JobTitle).HasMaxLength(60).IsRequired();
        builder.Property(x => x.SiteId).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(61).IsRequired();
        builder.Property(x => x.UpdatedBy).HasMaxLength(61).IsRequired();

        builder.HasOne(x => x.Site)
            .WithMany(x => x.Workers)
            .HasForeignKey(x => x.SiteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Documents)
            .WithOne(x => x.Worker)
            .HasForeignKey(x => x.WorkerId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Ignore(x => x.DomainEvents);
        builder.Ignore(x => x.FullName);
    }
}