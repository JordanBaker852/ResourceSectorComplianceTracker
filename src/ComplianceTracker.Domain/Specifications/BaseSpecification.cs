using System.Linq.Expressions;
using ComplianceTracker.Domain.Interfaces;

namespace ComplianceTracker.Domain.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; private set; } = x => true;
    public List<Expression<Func<T, object>>> Includes { get; } = [];
    public Expression<Func<T, object>>? OrderBy { get; private set; }
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    protected void AddCriteria(Expression<Func<T, bool>> criteria) => Criteria = criteria;
    protected void AddInclude(Expression<Func<T, object>> include) => Includes.Add(include);
    protected void AddOrderBy(Expression<Func<T, object>> orderBy) => OrderBy = orderBy;
    protected void AddOrderByDescending(Expression<Func<T, object>> descending) => OrderByDescending = descending;
}