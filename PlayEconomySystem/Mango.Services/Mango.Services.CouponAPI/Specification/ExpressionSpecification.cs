using System.Linq.Expressions;

namespace Mango.Services.CouponAPISpecification;

public class ExpressionSpecification<T> : Specification<T>
{
    private readonly Expression<Func<T, bool>> _predicate;

    public ExpressionSpecification(Expression<Func<T, bool>> predicate)
    {
        _predicate = predicate;
    }

    protected override Expression<Func<T, bool>> ToExpression() => _predicate;
}
