using System.Linq.Expressions;

namespace Mango.Services.CouponAPISpecification;

public abstract class Specification<T> : ISpecification<T>
{
    private readonly Lazy<Func<T, bool>> _compiledExpression;

    private Func<T, bool> CompiledExpression => _compiledExpression.Value;

    protected Specification()
    {
        _compiledExpression = new Lazy<Func<T, bool>>(
            () => Predicate.Compile());
    }

    protected abstract Expression<Func<T, bool>> ToExpression();

    public static Specification<T> operator !(Specification<T> spec)
        => new NotSpecification<T>(spec);

    public static Specification<T> operator &(Specification<T> first, Specification<T> second)
        => new AndSpecification<T>(first, second);

    public static Specification<T> operator |(Specification<T> first, Specification<T> second)
        => new OrSpecification<T>(first, second);

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        => specification.Predicate;

    public static implicit operator Func<T, bool>(Specification<T> specification)
        => specification.CompiledExpression;

    public Expression<Func<T, bool>> Predicate => ToExpression();

    public bool IsSatisfiedBy(T entity) => CompiledExpression(entity);
}