using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Specifications.Documents;

public class ExpiredDocumentsSpec : BaseSpecification<ComplianceDocument>
{
    public ExpiredDocumentsSpec()
    {
        AddCriteria(x => x.ExpiryDate <= DateTime.UtcNow);
        AddOrderByDescending(x => x.ExpiryDate);
    }
}