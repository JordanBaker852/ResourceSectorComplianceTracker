using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Specifications.Workers
{
    public class WorkerWithDocumentsSpec : BaseSpecification<Worker>
    {
        public WorkerWithDocumentsSpec(Guid id)
        {
            AddCriteria(x => x.Id == id);
            AddInclude(x => x.Documents);
        }
    }
}