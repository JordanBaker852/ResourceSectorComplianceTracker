using ComplianceTracker.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplianceTracker.Infrastructure.Persistance.Configurations;

public class ComplianceDocumentConfiguration : IEntityTypeConfiguration<ComplianceDocument>
{
    public void Configure(EntityTypeBuilder<ComplianceDocument> builder)
    {
        builder.HasKey(x =>x.Id);

        builder.Property(x => x.WorkerId).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.DocumentType).IsRequired();
        builder.Property(x => x.IssueDate).IsRequired();
        builder.Property(x => x.ExpiryDate).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(61).IsRequired();
        builder.Property(x => x.UpdatedBy).HasMaxLength(61);
        
        builder.Ignore(x => x.DomainEvents);
    }
}