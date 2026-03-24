using ComplianceTracker.Domain.Entites;

namespace ComplianceTracker.Domain.Specifications.Workers;

public class ActiveWorkersAtSiteSpec : BaseSpecification<Worker>
{
    public ActiveWorkersAtSiteSpec(Guid siteId)
    {
        AddCriteria(x => x.SiteId == siteId);
        AddOrderBy(x => x.Surname);
    }
}