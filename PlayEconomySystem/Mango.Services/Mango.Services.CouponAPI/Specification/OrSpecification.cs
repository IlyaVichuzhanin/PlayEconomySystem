using System.Linq.Expressions;

namespace Mango.Services.CouponAPISpecification;

internal class OrSpecification<T> : ComposeSpecification<T>
{
    public OrSpecification(Specification<T> first, Specification<T> second) : base(Expression.OrElse, first, second)
    {
    }
}
