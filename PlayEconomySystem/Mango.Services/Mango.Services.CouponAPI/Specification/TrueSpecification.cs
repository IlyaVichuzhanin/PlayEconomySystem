namespace Mango.Services.CouponAPISpecification;

public class TrueSpecification<T> : ExpressionSpecification<T>
{
    public TrueSpecification() : base(_ => true)
    {

    }
}