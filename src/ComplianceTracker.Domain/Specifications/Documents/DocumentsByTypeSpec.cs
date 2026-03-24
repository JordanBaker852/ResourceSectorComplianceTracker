using ComplianceTracker.Domain.Entites;
using ComplianceTracker.Domain.Enums;

namespace ComplianceTracker.Domain.Specifications.Documents
{
    public class DocumentsByTypeSpec : BaseSpecification<ComplianceDocument>
    {
        public DocumentsByTypeSpec(DocumentType type)
        {
            AddCriteria(x => x.DocumentType == type);
            AddOrderBy(x => x.ExpiryDate);
        }
    }
}