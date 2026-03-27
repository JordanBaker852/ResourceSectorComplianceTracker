using ComplianceTracker.Domain.Entites;
using ComplianceTracker.Domain.Entites.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ComplianceTracker.Infrastructure.Persistance.Configurations;

public class SiteConfiguration : IEntityTypeConfiguration<Site>
{
    public void Configure(EntityTypeBuilder<Site> builder)
    {
        builder.HasKey(x =>x.Id);
        
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(61).IsRequired();
        builder.Property(x => x.UpdatedBy).HasMaxLength(61).IsRequired();

        builder.OwnsOne(x => x.Address, address =>
        {
            address.ToTable("site_addresses");

            address.Property(x => x.Street).HasColumnName("street").HasMaxLength(60).IsRequired();
            address.Property(x => x.Suburb).HasColumnName("suburb").HasMaxLength(40).IsRequired();
            address.Property(x => x.State).HasColumnName("state").HasMaxLength(3).IsRequired();
            address.Property(x => x.PostCode).HasColumnName("post_code").HasMaxLength(10).IsRequired();
            address.Property(x => x.Country).HasColumnName("country").HasDefaultValue("Australia");
        });

        builder.Ignore(x => x.DomainEvents);
    }
}