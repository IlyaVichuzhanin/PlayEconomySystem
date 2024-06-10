using System.Linq.Expressions;

namespace Mango.Services.CouponAPISpecification;

public class FalseSpecification<T> : ExpressionSpecification<T>
{
    protected internal FalseSpecification() : base(_ => false)
    {
    }
}