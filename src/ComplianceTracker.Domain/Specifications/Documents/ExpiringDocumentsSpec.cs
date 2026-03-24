using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Specifications.Documents;

public class ExpiringDocumentsSpec : BaseSpecification<ComplianceDocument>
{
    public ExpiringDocumentsSpec(uint thresholdDays)
    {
        AddCriteria(x => x.ExpiryDate <= DateTime.UtcNow.AddDays(thresholdDays));
        AddOrderByDescending(x => x.ExpiryDate);
    }
}