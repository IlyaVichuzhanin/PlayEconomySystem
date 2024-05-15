using System.Linq.Expressions;

namespace Play.Catalog.Service.Specification;

internal class AndSpecification<T> : ComposeSpecification<T>
{
    public AndSpecification(Specification<T> first, Specification<T> second) : base(Expression.AndAlso, first, second)
    {
    }
}
