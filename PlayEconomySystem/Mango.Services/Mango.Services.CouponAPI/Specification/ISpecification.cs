namespace Mango.Services.CouponAPISpecification;

public interface ISpecification<in T>
{
    bool IsSatisfiedBy(T entity);
}
