using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Specifications.Documents
{
    public class DocumentsByWorkerSpec : BaseSpecification<ComplianceDocument>
    {
        public DocumentsByWorkerSpec(Guid workerId)
        {
            AddCriteria(x => x.WorkerId == workerId);
            AddOrderBy(x => x.IssueDate);
        }
    }
}