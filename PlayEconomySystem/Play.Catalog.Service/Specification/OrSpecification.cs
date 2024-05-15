using System.Linq.Expressions;

namespace Play.Catalog.Service.Specification;

internal class OrSpecification<T> : ComposeSpecification<T>
{
    public OrSpecification(Specification<T> first, Specification<T> second) : base(Expression.OrElse, first, second)
    {
    }
}
